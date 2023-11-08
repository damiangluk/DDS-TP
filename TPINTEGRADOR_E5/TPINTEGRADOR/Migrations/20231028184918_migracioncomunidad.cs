using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class migracioncomunidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Persona_PersonaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Comunidades",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios",
                column: "PersonaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Persona_PersonaId",
                table: "Usuarios",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Persona_PersonaId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Comunidades");

            migrationBuilder.AlterColumn<int>(
                name: "PersonaId",
                table: "Usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios",
                column: "PersonaId",
                unique: true,
                filter: "[PersonaId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Persona_PersonaId",
                table: "Usuarios",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id");
        }
    }
}
