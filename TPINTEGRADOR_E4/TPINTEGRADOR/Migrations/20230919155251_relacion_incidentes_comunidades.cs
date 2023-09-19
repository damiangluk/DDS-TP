using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class relacion_incidentes_comunidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProveedorId",
                table: "Incidentes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComunidadIncidente",
                columns: table => new
                {
                    ComunidadesId = table.Column<int>(type: "int", nullable: false),
                    IncidentesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComunidadIncidente", x => new { x.ComunidadesId, x.IncidentesId });
                    table.ForeignKey(
                        name: "FK_ComunidadIncidente_Comunidades_ComunidadesId",
                        column: x => x.ComunidadesId,
                        principalTable: "Comunidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComunidadIncidente_Incidentes_IncidentesId",
                        column: x => x.IncidentesId,
                        principalTable: "Incidentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_ProveedorId",
                table: "Incidentes",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComunidadIncidente_IncidentesId",
                table: "ComunidadIncidente",
                column: "IncidentesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_ProveedorDeServicio_ProveedorId",
                table: "Incidentes",
                column: "ProveedorId",
                principalTable: "ProveedorDeServicio",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_ProveedorDeServicio_ProveedorId",
                table: "Incidentes");

            migrationBuilder.DropTable(
                name: "ComunidadIncidente");

            migrationBuilder.DropIndex(
                name: "IX_Incidentes_ProveedorId",
                table: "Incidentes");

            migrationBuilder.DropColumn(
                name: "ProveedorId",
                table: "Incidentes");
        }
    }
}
