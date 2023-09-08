using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class persistencia_entrega_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "ProveedorDeServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProveedorDeServicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comunidad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadMiembrosAfectados = table.Column<int>(type: "int", nullable: false),
                    AdministradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunidad", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "Localizacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoLocalizacion1 = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntidadId = table.Column<int>(type: "int", nullable: false),
                    TipoLocalizacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Localizacion_Entidad_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    LocalizacionId = table.Column<int>(type: "int", nullable: false),
                    Informe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaApertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidente_Localizacion_Id",
                        column: x => x.Id,
                        principalTable: "Localizacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalizacionActualId = table.Column<int>(type: "int", nullable: false),
                    LocalizacionDeInteresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_Localizacion_LocalizacionActualId",
                        column: x => x.LocalizacionActualId,
                        principalTable: "Localizacion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persona_Localizacion_LocalizacionDeInteresId",
                        column: x => x.LocalizacionDeInteresId,
                        principalTable: "Localizacion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FechasNotificacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FechasNotificacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FechasNotificacion_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Rol1 = table.Column<int>(type: "int", nullable: false),
                    ComunidadId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    MedioId = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_Participacion_Persona_Id",
                        column: x => x.Id,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Persona_Id",
                        column: x => x.Id,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comunidad_AdministradorId",
                table: "Comunidad",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entidad_PersonaId",
                table: "Entidad",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_FechasNotificacion_PersonaId",
                table: "FechasNotificacion",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Localizacion_EntidadId",
                table: "Localizacion",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_LocalizacionActualId",
                table: "Persona",
                column: "LocalizacionActualId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_LocalizacionDeInteresId",
                table: "Persona",
                column: "LocalizacionDeInteresId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comunidad_Persona_AdministradorId",
                table: "Comunidad",
                column: "AdministradorId",
                principalTable: "Persona",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entidad_Persona_PersonaId",
                table: "Entidad",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entidad_Persona_PersonaId",
                table: "Entidad");

            migrationBuilder.DropTable(
                name: "FechasNotificacion");

            migrationBuilder.DropTable(
                name: "Incidente");

            migrationBuilder.DropTable(
                name: "Participacion");

            migrationBuilder.DropTable(
                name: "ProveedorDeServicio");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Comunidad");

            migrationBuilder.DropTable(
                name: "Medios");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Localizacion");

            migrationBuilder.DropTable(
                name: "Entidad");
        }
    }
}
