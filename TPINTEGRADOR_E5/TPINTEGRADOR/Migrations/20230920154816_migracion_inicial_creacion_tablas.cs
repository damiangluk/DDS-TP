using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class migracion_inicial_creacion_tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoEntidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localizacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoLocalizacion = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacion", x => x.Id);
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
                name: "Ubicacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitud = table.Column<double>(type: "float", nullable: false),
                    Longitud = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntidadLocalizacion",
                columns: table => new
                {
                    EntidadesId = table.Column<int>(type: "int", nullable: false),
                    LocalizacionesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadLocalizacion", x => new { x.EntidadesId, x.LocalizacionesId });
                    table.ForeignKey(
                        name: "FK_EntidadLocalizacion_Entidades_EntidadesId",
                        column: x => x.EntidadesId,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EntidadLocalizacion_Localizacion_LocalizacionesId",
                        column: x => x.LocalizacionesId,
                        principalTable: "Localizacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocalizacionActualId = table.Column<int>(type: "int", nullable: true),
                    LocalizacionDeInteresId = table.Column<int>(type: "int", nullable: true)
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
                name: "SuperServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperServicio_ProveedorDeServicio_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "ProveedorDeServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Establecimiento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UbicacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establecimiento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Establecimiento_Ubicacion_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "Ubicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Comunidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CantidadMiembrosAfectados = table.Column<int>(type: "int", nullable: false),
                    AdministradorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comunidades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comunidades_Persona_AdministradorId",
                        column: x => x.AdministradorId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EntidadPersona_Persona_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Organismo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncargadoId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoOrganismo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organismo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Organismo_Persona_EncargadoId",
                        column: x => x.EncargadoId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EntidadSuperServicio",
                columns: table => new
                {
                    EntidadesId = table.Column<int>(type: "int", nullable: false),
                    ServiciosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadSuperServicio", x => new { x.EntidadesId, x.ServiciosId });
                    table.ForeignKey(
                        name: "FK_EntidadSuperServicio_Entidades_EntidadesId",
                        column: x => x.EntidadesId,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EntidadSuperServicio_SuperServicio_ServiciosId",
                        column: x => x.ServiciosId,
                        principalTable: "SuperServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Incidentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    LocalizacionId = table.Column<int>(type: "int", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: true),
                    Informe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaApertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaCierre = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Incidentes_Localizacion_LocalizacionId",
                        column: x => x.LocalizacionId,
                        principalTable: "Localizacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Incidentes_ProveedorDeServicio_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "ProveedorDeServicio",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Incidentes_SuperServicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "SuperServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PersonaSuperServicio",
                columns: table => new
                {
                    InteresesId = table.Column<int>(type: "int", nullable: false),
                    PersonasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonaSuperServicio", x => new { x.InteresesId, x.PersonasId });
                    table.ForeignKey(
                        name: "FK_PersonaSuperServicio_Persona_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonaSuperServicio_SuperServicio_InteresesId",
                        column: x => x.InteresesId,
                        principalTable: "SuperServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ServiciosPorGrupos",
                columns: table => new
                {
                    AgrupacionesId = table.Column<int>(type: "int", nullable: false),
                    ServiciosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosPorGrupos", x => new { x.AgrupacionesId, x.ServiciosId });
                    table.ForeignKey(
                        name: "FK_ServiciosPorGrupos_SuperServicio_AgrupacionesId",
                        column: x => x.AgrupacionesId,
                        principalTable: "SuperServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ServiciosPorGrupos_SuperServicio_ServiciosId",
                        column: x => x.ServiciosId,
                        principalTable: "SuperServicio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prestacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Habilitado = table.Column<bool>(type: "bit", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    EstablecimientoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestacion_Establecimiento_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Prestacion_SuperServicio_ServicioId",
                        column: x => x.ServicioId,
                        principalTable: "SuperServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstablecimientoId = table.Column<int>(type: "int", nullable: false),
                    EntidadId = table.Column<int>(type: "int", nullable: false),
                    NumeroSucursal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sucursal_Entidades_EntidadId",
                        column: x => x.EntidadId,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Sucursal_Establecimiento_EstablecimientoId",
                        column: x => x.EstablecimientoId,
                        principalTable: "Establecimiento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ComunidadSuperServicio",
                columns: table => new
                {
                    ComunidadesId = table.Column<int>(type: "int", nullable: false),
                    InteresesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComunidadSuperServicio", x => new { x.ComunidadesId, x.InteresesId });
                    table.ForeignKey(
                        name: "FK_ComunidadSuperServicio_Comunidades_ComunidadesId",
                        column: x => x.ComunidadesId,
                        principalTable: "Comunidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ComunidadSuperServicio_SuperServicio_InteresesId",
                        column: x => x.InteresesId,
                        principalTable: "SuperServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Participacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rol = table.Column<int>(type: "int", nullable: false),
                    ComunidadId = table.Column<int>(type: "int", nullable: false),
                    PersonaId = table.Column<int>(type: "int", nullable: false),
                    MedioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participacion_Comunidades_ComunidadId",
                        column: x => x.ComunidadId,
                        principalTable: "Comunidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Participacion_Medios_MedioId",
                        column: x => x.MedioId,
                        principalTable: "Medios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Participacion_Persona_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Persona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EntidadOrganismo",
                columns: table => new
                {
                    EntidadesId = table.Column<int>(type: "int", nullable: false),
                    OrganismosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntidadOrganismo", x => new { x.EntidadesId, x.OrganismosId });
                    table.ForeignKey(
                        name: "FK_EntidadOrganismo_Entidades_EntidadesId",
                        column: x => x.EntidadesId,
                        principalTable: "Entidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EntidadOrganismo_Organismo_OrganismosId",
                        column: x => x.OrganismosId,
                        principalTable: "Organismo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ComunidadIncidente",
                columns: table => new
                {
                    ComunidadesId = table.Column<int>(type: "int", nullable: false),
                    IncidentesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComunidadIncidente", x => new { x.ComunidadesId, x.IncidentesId });
                    table.ForeignKey(
                        name: "FK_ComunidadIncidente_Comunidades_ComunidadesId",
                        column: x => x.ComunidadesId,
                        principalTable: "Comunidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ComunidadIncidente_Incidentes_IncidentesId",
                        column: x => x.IncidentesId,
                        principalTable: "Incidentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comunidades_AdministradorId",
                table: "Comunidades",
                column: "AdministradorId");

            migrationBuilder.CreateIndex(
                name: "IX_ComunidadIncidente_IncidentesId",
                table: "ComunidadIncidente",
                column: "IncidentesId");

            migrationBuilder.CreateIndex(
                name: "IX_ComunidadSuperServicio_InteresesId",
                table: "ComunidadSuperServicio",
                column: "InteresesId");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadLocalizacion_LocalizacionesId",
                table: "EntidadLocalizacion",
                column: "LocalizacionesId");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadOrganismo_OrganismosId",
                table: "EntidadOrganismo",
                column: "OrganismosId");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadPersona_PersonasId",
                table: "EntidadPersona",
                column: "PersonasId");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadSuperServicio_ServiciosId",
                table: "EntidadSuperServicio",
                column: "ServiciosId");

            migrationBuilder.CreateIndex(
                name: "IX_Establecimiento_UbicacionId",
                table: "Establecimiento",
                column: "UbicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_FechasNotificacion_PersonaId",
                table: "FechasNotificacion",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_LocalizacionId",
                table: "Incidentes",
                column: "LocalizacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_ProveedorId",
                table: "Incidentes",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_ServicioId",
                table: "Incidentes",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_Organismo_EncargadoId",
                table: "Organismo",
                column: "EncargadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Participacion_ComunidadId",
                table: "Participacion",
                column: "ComunidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Participacion_MedioId",
                table: "Participacion",
                column: "MedioId");

            migrationBuilder.CreateIndex(
                name: "IX_Participacion_PersonaId",
                table: "Participacion",
                column: "PersonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_LocalizacionActualId",
                table: "Persona",
                column: "LocalizacionActualId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_LocalizacionDeInteresId",
                table: "Persona",
                column: "LocalizacionDeInteresId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaSuperServicio_PersonasId",
                table: "PersonaSuperServicio",
                column: "PersonasId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestacion_EstablecimientoId",
                table: "Prestacion",
                column: "EstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestacion_ServicioId",
                table: "Prestacion",
                column: "ServicioId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosPorGrupos_ServiciosId",
                table: "ServiciosPorGrupos",
                column: "ServiciosId");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_EntidadId",
                table: "Sucursal",
                column: "EntidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Sucursal_EstablecimientoId",
                table: "Sucursal",
                column: "EstablecimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperServicio_ProveedorId",
                table: "SuperServicio",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PersonaId",
                table: "Usuarios",
                column: "PersonaId",
                unique: true,
                filter: "[PersonaId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComunidadIncidente");

            migrationBuilder.DropTable(
                name: "ComunidadSuperServicio");

            migrationBuilder.DropTable(
                name: "EntidadLocalizacion");

            migrationBuilder.DropTable(
                name: "EntidadOrganismo");

            migrationBuilder.DropTable(
                name: "EntidadPersona");

            migrationBuilder.DropTable(
                name: "EntidadSuperServicio");

            migrationBuilder.DropTable(
                name: "FechasNotificacion");

            migrationBuilder.DropTable(
                name: "Participacion");

            migrationBuilder.DropTable(
                name: "PersonaSuperServicio");

            migrationBuilder.DropTable(
                name: "Prestacion");

            migrationBuilder.DropTable(
                name: "ServiciosPorGrupos");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Incidentes");

            migrationBuilder.DropTable(
                name: "Organismo");

            migrationBuilder.DropTable(
                name: "Comunidades");

            migrationBuilder.DropTable(
                name: "Medios");

            migrationBuilder.DropTable(
                name: "Entidades");

            migrationBuilder.DropTable(
                name: "Establecimiento");

            migrationBuilder.DropTable(
                name: "SuperServicio");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Ubicacion");

            migrationBuilder.DropTable(
                name: "ProveedorDeServicio");

            migrationBuilder.DropTable(
                name: "Localizacion");
        }
    }
}
