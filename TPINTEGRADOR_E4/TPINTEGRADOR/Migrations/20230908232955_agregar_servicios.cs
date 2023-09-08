using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    /// <inheritdoc />
    public partial class agregar_servicios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comunidad_Persona_AdministradorId",
                table: "Comunidad");

            migrationBuilder.DropForeignKey(
                name: "FK_Entidad_Persona_PersonaId",
                table: "Entidad");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidente_Localizacion_Id",
                table: "Incidente");

            migrationBuilder.DropForeignKey(
                name: "FK_Localizacion_Entidad_EntidadId",
                table: "Localizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Participacion_Comunidad_Id",
                table: "Participacion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incidente",
                table: "Incidente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entidad",
                table: "Entidad");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comunidad",
                table: "Comunidad");

            migrationBuilder.RenameTable(
                name: "Incidente",
                newName: "Incidentes");

            migrationBuilder.RenameTable(
                name: "Entidad",
                newName: "Entidades");

            migrationBuilder.RenameTable(
                name: "Comunidad",
                newName: "Comunidades");

            migrationBuilder.RenameIndex(
                name: "IX_Entidad_PersonaId",
                table: "Entidades",
                newName: "IX_Entidades_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Comunidad_AdministradorId",
                table: "Comunidades",
                newName: "IX_Comunidades_AdministradorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incidentes",
                table: "Incidentes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entidades",
                table: "Entidades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comunidades",
                table: "Comunidades",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SuperServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProveedorId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperServicio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuperServicio_ProveedorDeServicio_Id",
                        column: x => x.Id,
                        principalTable: "ProveedorDeServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComunidadSuperServicio_SuperServicio_InteresesId",
                        column: x => x.InteresesId,
                        principalTable: "SuperServicio",
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntidadSuperServicio_SuperServicio_ServiciosId",
                        column: x => x.ServiciosId,
                        principalTable: "SuperServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonaSuperServicio_SuperServicio_InteresesId",
                        column: x => x.InteresesId,
                        principalTable: "SuperServicio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiciosPorGrupos_SuperServicio_ServiciosId",
                        column: x => x.ServiciosId,
                        principalTable: "SuperServicio",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComunidadSuperServicio_InteresesId",
                table: "ComunidadSuperServicio",
                column: "InteresesId");

            migrationBuilder.CreateIndex(
                name: "IX_EntidadSuperServicio_ServiciosId",
                table: "EntidadSuperServicio",
                column: "ServiciosId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonaSuperServicio_PersonasId",
                table: "PersonaSuperServicio",
                column: "PersonasId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosPorGrupos_ServiciosId",
                table: "ServiciosPorGrupos",
                column: "ServiciosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comunidades_Persona_AdministradorId",
                table: "Comunidades",
                column: "AdministradorId",
                principalTable: "Persona",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entidades_Persona_PersonaId",
                table: "Entidades",
                column: "PersonaId",
                principalTable: "Persona",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Localizacion_Id",
                table: "Incidentes",
                column: "Id",
                principalTable: "Localizacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_SuperServicio_Id",
                table: "Incidentes",
                column: "Id",
                principalTable: "SuperServicio",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Localizacion_Entidades_EntidadId",
                table: "Localizacion",
                column: "EntidadId",
                principalTable: "Entidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participacion_Comunidades_Id",
                table: "Participacion",
                column: "Id",
                principalTable: "Comunidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comunidades_Persona_AdministradorId",
                table: "Comunidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Entidades_Persona_PersonaId",
                table: "Entidades");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Localizacion_Id",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_SuperServicio_Id",
                table: "Incidentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Localizacion_Entidades_EntidadId",
                table: "Localizacion");

            migrationBuilder.DropForeignKey(
                name: "FK_Participacion_Comunidades_Id",
                table: "Participacion");

            migrationBuilder.DropTable(
                name: "ComunidadSuperServicio");

            migrationBuilder.DropTable(
                name: "EntidadSuperServicio");

            migrationBuilder.DropTable(
                name: "PersonaSuperServicio");

            migrationBuilder.DropTable(
                name: "ServiciosPorGrupos");

            migrationBuilder.DropTable(
                name: "SuperServicio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incidentes",
                table: "Incidentes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entidades",
                table: "Entidades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comunidades",
                table: "Comunidades");

            migrationBuilder.RenameTable(
                name: "Incidentes",
                newName: "Incidente");

            migrationBuilder.RenameTable(
                name: "Entidades",
                newName: "Entidad");

            migrationBuilder.RenameTable(
                name: "Comunidades",
                newName: "Comunidad");

            migrationBuilder.RenameIndex(
                name: "IX_Entidades_PersonaId",
                table: "Entidad",
                newName: "IX_Entidad_PersonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Comunidades_AdministradorId",
                table: "Comunidad",
                newName: "IX_Comunidad_AdministradorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incidente",
                table: "Incidente",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entidad",
                table: "Entidad",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comunidad",
                table: "Comunidad",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Incidente_Localizacion_Id",
                table: "Incidente",
                column: "Id",
                principalTable: "Localizacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Localizacion_Entidad_EntidadId",
                table: "Localizacion",
                column: "EntidadId",
                principalTable: "Entidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participacion_Comunidad_Id",
                table: "Participacion",
                column: "Id",
                principalTable: "Comunidad",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
