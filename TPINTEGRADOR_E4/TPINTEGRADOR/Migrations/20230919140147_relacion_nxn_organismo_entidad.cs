using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class relacion_nxn_organismo_entidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organismo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    EncargadoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoOrganismo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organismo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organismo_Persona_Id",
                        column: x => x.Id,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntidadOrganismo",
                columns: table => new
                {
                    EntidadesId = table.Column<int>(type: "int", nullable: false),
                    OrganismosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadOrganismo", x => new { x.EntidadesId, x.OrganismosId });
                    table.ForeignKey(
                        name: "FK_EntidadOrganismo_Entidades_EntidadesId",
                        column: x => x.EntidadesId,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntidadOrganismo_Organismo_OrganismosId",
                        column: x => x.OrganismosId,
                        principalTable: "Organismo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntidadOrganismo_OrganismosId",
                table: "EntidadOrganismo",
                column: "OrganismosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntidadOrganismo");

            migrationBuilder.DropTable(
                name: "Organismo");
        }
    }
}
