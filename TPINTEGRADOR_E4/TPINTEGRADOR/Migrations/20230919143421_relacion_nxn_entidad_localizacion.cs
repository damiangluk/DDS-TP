using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class relacion_nxn_entidad_localizacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Localizacion_Entidades_EntidadId",
                table: "Localizacion");

            migrationBuilder.DropIndex(
                name: "IX_Localizacion_EntidadId",
                table: "Localizacion");

            migrationBuilder.DropColumn(
                name: "EntidadId",
                table: "Localizacion");

            migrationBuilder.CreateTable(
                name: "EntidadLocalizacion",
                columns: table => new
                {
                    EntidadesId = table.Column<int>(type: "int", nullable: false),
                    LocalizacionesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadLocalizacion", x => new { x.EntidadesId, x.LocalizacionesId });
                    table.ForeignKey(
                        name: "FK_EntidadLocalizacion_Entidades_EntidadesId",
                        column: x => x.EntidadesId,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntidadLocalizacion_Localizacion_LocalizacionesId",
                        column: x => x.LocalizacionesId,
                        principalTable: "Localizacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntidadLocalizacion_LocalizacionesId",
                table: "EntidadLocalizacion",
                column: "LocalizacionesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntidadLocalizacion");

            migrationBuilder.AddColumn<int>(
                name: "EntidadId",
                table: "Localizacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Localizacion_EntidadId",
                table: "Localizacion",
                column: "EntidadId");

            migrationBuilder.AddForeignKey(
                name: "FK_Localizacion_Entidades_EntidadId",
                table: "Localizacion",
                column: "EntidadId",
                principalTable: "Entidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
