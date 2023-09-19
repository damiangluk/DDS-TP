using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class relacion_nxn_servicio_establecimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Prestacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    EstablecimientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestacion_Establecimiento_Id",
                        column: x => x.Id,
                        principalTable: "Establecimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestacion_SuperServicio_Id",
                        column: x => x.Id,
                        principalTable: "SuperServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestacion");
        }
    }
}
