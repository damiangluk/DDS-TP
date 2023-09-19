using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class relacion_nxn_entidad_persona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entidades_Persona_PersonaId",
                table: "Entidades");

            migrationBuilder.DropIndex(
                name: "IX_Entidades_PersonaId",
                table: "Entidades");

            migrationBuilder.DropColumn(
                name: "PersonaId",
                table: "Entidades");

            migrationBuilder.CreateTable(
                name: "EntidadPersona",
                columns: table => new
                {
                    EntidadesInteresadasId = table.Column<int>(type: "int", nullable: false),
                    PersonasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadPersona", x => new { x.EntidadesInteresadasId, x.PersonasId });
                    table.ForeignKey(
                        name: "FK_EntidadPersona_Entidades_EntidadesInteresadasId",
                        column: x => x.EntidadesInteresadasId,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntidadPersona_Persona_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntidadPersona_PersonasId",
                table: "EntidadPersona",
                column: "PersonasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntidadPersona");

            migrationBuilder.AddColumn<int>(
                name: "PersonaId",
                table: "Entidades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Entidades_PersonaId",
                table: "Entidades",
                column: "PersonaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entidades_Persona_PersonaId",
                table: "Entidades",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id");
        }
    }
}
