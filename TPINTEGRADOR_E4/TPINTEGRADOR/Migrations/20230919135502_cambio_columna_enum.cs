using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class cambio_columna_enum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TipoLocalizacion1",
                table: "Localizacion");

            migrationBuilder.DropColumn(
                name: "TipoEntidad1",
                table: "Entidades");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TipoLocalizacion1",
                table: "Localizacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoEntidad1",
                table: "Entidades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
