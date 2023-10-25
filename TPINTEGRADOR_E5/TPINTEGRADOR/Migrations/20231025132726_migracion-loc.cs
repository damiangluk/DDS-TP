using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class migracionloc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntidadLocalizacion_Localizacion_LocalizacionesId",
                table: "EntidadLocalizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Localizacion_LocalizacionId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Localizacion_LocalizacionActualId",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Localizacion_LocalizacionDeInteresId",
                table: "Persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Localizacion",
                table: "Localizacion");

            migrationBuilder.RenameTable(
                name: "Localizacion",
                newName: "Localizaciones");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Localizaciones",
                table: "Localizaciones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntidadLocalizacion_Localizaciones_LocalizacionesId",
                table: "EntidadLocalizacion",
                column: "LocalizacionesId",
                principalTable: "Localizaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Localizaciones_LocalizacionId",
                table: "Incidentes",
                column: "LocalizacionId",
                principalTable: "Localizaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Localizaciones_LocalizacionActualId",
                table: "Persona",
                column: "LocalizacionActualId",
                principalTable: "Localizaciones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Localizaciones_LocalizacionDeInteresId",
                table: "Persona",
                column: "LocalizacionDeInteresId",
                principalTable: "Localizaciones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntidadLocalizacion_Localizaciones_LocalizacionesId",
                table: "EntidadLocalizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Localizaciones_LocalizacionId",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Localizaciones_LocalizacionActualId",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Localizaciones_LocalizacionDeInteresId",
                table: "Persona");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Localizaciones",
                table: "Localizaciones");

            migrationBuilder.RenameTable(
                name: "Localizaciones",
                newName: "Localizacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Localizacion",
                table: "Localizacion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EntidadLocalizacion_Localizacion_LocalizacionesId",
                table: "EntidadLocalizacion",
                column: "LocalizacionesId",
                principalTable: "Localizacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Localizacion_LocalizacionId",
                table: "Incidentes",
                column: "LocalizacionId",
                principalTable: "Localizacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Localizacion_LocalizacionActualId",
                table: "Persona",
                column: "LocalizacionActualId",
                principalTable: "Localizacion",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_Localizacion_LocalizacionDeInteresId",
                table: "Persona",
                column: "LocalizacionDeInteresId",
                principalTable: "Localizacion",
                principalColumn: "Id");
        }
    }
}
