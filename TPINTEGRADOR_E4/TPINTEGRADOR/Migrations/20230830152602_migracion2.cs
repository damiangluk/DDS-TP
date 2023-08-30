using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class migracion2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocalizacionActualId",
                table: "Persona",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalizacionDeInteresId",
                table: "Persona",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Comunidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CantidadMiembrosAfectados = table.Column<int>(type: "int", nullable: false),
                    AdministradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comunidad_Persona_Id",
                        column: x => x.Id,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Entidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEntidad1 = table.Column<int>(type: "int", nullable: false),
                    TipoEntidad = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entidad_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Medios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoMedio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localizacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoLocalizacion1 = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoLocalizacion = table.Column<int>(type: "int", nullable: false),
                    EntidadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localizacion_Entidad_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidad",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Participacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Rol1 = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    ComunidadId = table.Column<int>(type: "int", nullable: false),
                    MedioId = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    PersonaId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participacion_Comunidad_Id",
                        column: x => x.Id,
                        principalTable: "Comunidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participacion_Medios_Id",
                        column: x => x.Id,
                        principalTable: "Medios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participacion_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participacion_Persona_PersonaId1",
                        column: x => x.PersonaId1,
                        principalTable: "Persona",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persona_LocalizacionActualId",
                table: "Persona",
                column: "LocalizacionActualId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_LocalizacionDeInteresId",
                table: "Persona",
                column: "LocalizacionDeInteresId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_PersonaId",
                table: "Entidad",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Localizacion_EntidadId",
                table: "Localizacion",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Participacion_PersonaId",
                table: "Participacion",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Participacion_PersonaId1",
                table: "Participacion",
                column: "PersonaId1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Localizacion_LocalizacionActualId",
                table: "Persona");

            migrationBuilder.DropForeignKey(
                name: "FK_Persona_Localizacion_LocalizacionDeInteresId",
                table: "Persona");

            migrationBuilder.DropTable(
                name: "Localizacion");

            migrationBuilder.DropTable(
                name: "Participacion");

            migrationBuilder.DropTable(
                name: "Entidad");

            migrationBuilder.DropTable(
                name: "Comunidad");

            migrationBuilder.DropTable(
                name: "Medios");

            migrationBuilder.DropIndex(
                name: "IX_Persona_LocalizacionActualId",
                table: "Persona");

            migrationBuilder.DropIndex(
                name: "IX_Persona_LocalizacionDeInteresId",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "LocalizacionActualId",
                table: "Persona");

            migrationBuilder.DropColumn(
                name: "LocalizacionDeInteresId",
                table: "Persona");
        }
    }
}
