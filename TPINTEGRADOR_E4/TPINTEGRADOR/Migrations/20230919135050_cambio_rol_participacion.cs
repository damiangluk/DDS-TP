using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class cambio_rol_participacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rol1",
                table: "Participacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rol1",
                table: "Participacion",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
