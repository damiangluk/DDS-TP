using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class Cambiosrotundosenrankings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntidadOrganismo_Organismo_OrganismosId",
                table: "EntidadOrganismo");

            migrationBuilder.DropForeignKey(
                name: "FK_Organismo_Persona_EncargadoId",
                table: "Organismo");

            migrationBuilder.DropForeignKey(
                name: "FK_Participacion_Comunidades_ComunidadId",
                table: "Participacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Participacion_Medios_MedioId",
                table: "Participacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Participacion_Persona_PersonaId",
                table: "Participacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participacion",
                table: "Participacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organismo",
                table: "Organismo");

            migrationBuilder.RenameTable(
                name: "Participacion",
                newName: "Participaciones");

            migrationBuilder.RenameTable(
                name: "Organismo",
                newName: "Organismos");

            migrationBuilder.RenameColumn(
                name: "Ranking",
                table: "ImpactoIncidentes",
                newName: "Json");

            migrationBuilder.RenameColumn(
                name: "FechaRanking",
                table: "ImpactoIncidentes",
                newName: "Fecha");

            migrationBuilder.RenameIndex(
                name: "IX_Participacion_PersonaId",
                table: "Participaciones",
                newName: "IX_Participaciones_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Participacion_MedioId",
                table: "Participaciones",
                newName: "IX_Participaciones_MedioId");

            migrationBuilder.RenameIndex(
                name: "IX_Participacion_ComunidadId",
                table: "Participaciones",
                newName: "IX_Participaciones_ComunidadId");

            migrationBuilder.RenameIndex(
                name: "IX_Organismo_EncargadoId",
                table: "Organismos",
                newName: "IX_Organismos_EncargadoId");

            migrationBuilder.AddColumn<int>(
                name: "TipoRanking",
                table: "ImpactoIncidentes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participaciones",
                table: "Participaciones",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organismos",
                table: "Organismos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntidadOrganismo_Organismos_OrganismosId",
                table: "EntidadOrganismo",
                column: "OrganismosId",
                principalTable: "Organismos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organismos_Persona_EncargadoId",
                table: "Organismos",
                column: "EncargadoId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participaciones_Comunidades_ComunidadId",
                table: "Participaciones",
                column: "ComunidadId",
                principalTable: "Comunidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participaciones_Medios_MedioId",
                table: "Participaciones",
                column: "MedioId",
                principalTable: "Medios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participaciones_Persona_PersonaId",
                table: "Participaciones",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntidadOrganismo_Organismos_OrganismosId",
                table: "EntidadOrganismo");

            migrationBuilder.DropForeignKey(
                name: "FK_Organismos_Persona_EncargadoId",
                table: "Organismos");

            migrationBuilder.DropForeignKey(
                name: "FK_Participaciones_Comunidades_ComunidadId",
                table: "Participaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Participaciones_Medios_MedioId",
                table: "Participaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Participaciones_Persona_PersonaId",
                table: "Participaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Participaciones",
                table: "Participaciones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organismos",
                table: "Organismos");

            migrationBuilder.DropColumn(
                name: "TipoRanking",
                table: "ImpactoIncidentes");

            migrationBuilder.RenameTable(
                name: "Participaciones",
                newName: "Participacion");

            migrationBuilder.RenameTable(
                name: "Organismos",
                newName: "Organismo");

            migrationBuilder.RenameColumn(
                name: "Json",
                table: "ImpactoIncidentes",
                newName: "Ranking");

            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "ImpactoIncidentes",
                newName: "FechaRanking");

            migrationBuilder.RenameIndex(
                name: "IX_Participaciones_PersonaId",
                table: "Participacion",
                newName: "IX_Participacion_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Participaciones_MedioId",
                table: "Participacion",
                newName: "IX_Participacion_MedioId");

            migrationBuilder.RenameIndex(
                name: "IX_Participaciones_ComunidadId",
                table: "Participacion",
                newName: "IX_Participacion_ComunidadId");

            migrationBuilder.RenameIndex(
                name: "IX_Organismos_EncargadoId",
                table: "Organismo",
                newName: "IX_Organismo_EncargadoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Participacion",
                table: "Participacion",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organismo",
                table: "Organismo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntidadOrganismo_Organismo_OrganismosId",
                table: "EntidadOrganismo",
                column: "OrganismosId",
                principalTable: "Organismo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organismo_Persona_EncargadoId",
                table: "Organismo",
                column: "EncargadoId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participacion_Comunidades_ComunidadId",
                table: "Participacion",
                column: "ComunidadId",
                principalTable: "Comunidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participacion_Medios_MedioId",
                table: "Participacion",
                column: "MedioId",
                principalTable: "Medios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participacion_Persona_PersonaId",
                table: "Participacion",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
