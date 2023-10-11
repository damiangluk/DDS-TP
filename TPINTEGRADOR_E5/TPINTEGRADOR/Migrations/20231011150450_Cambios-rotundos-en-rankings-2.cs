using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class Cambiosrotundosenrankings2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ImpactoIncidentes",
                table: "ImpactoIncidentes");

            migrationBuilder.RenameTable(
                name: "ImpactoIncidentes",
                newName: "Rankings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rankings",
                table: "Rankings",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Rankings",
                table: "Rankings");

            migrationBuilder.RenameTable(
                name: "Rankings",
                newName: "ImpactoIncidentes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ImpactoIncidentes",
                table: "ImpactoIncidentes",
                column: "Id");
        }
    }
}
