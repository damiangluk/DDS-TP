﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TPINTEGRADOR.Models.Sistema;

#nullable disable

namespace TPINTEGRADOR.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20231025151722_cambios_logueo")]
    partial class cambios_logueo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ComunidadIncidente", b =>
                {
                    b.Property<int>("ComunidadesId")
                        .HasColumnType("int");

                    b.Property<int>("IncidentesId")
                        .HasColumnType("int");

                    b.HasKey("ComunidadesId", "IncidentesId");

                    b.HasIndex("IncidentesId");

                    b.ToTable("ComunidadIncidente");
                });

            modelBuilder.Entity("ComunidadSuperServicio", b =>
                {
                    b.Property<int>("ComunidadesId")
                        .HasColumnType("int");

                    b.Property<int>("InteresesId")
                        .HasColumnType("int");

                    b.HasKey("ComunidadesId", "InteresesId");

                    b.HasIndex("InteresesId");

                    b.ToTable("ComunidadSuperServicio");
                });

            modelBuilder.Entity("EntidadLocalizacion", b =>
                {
                    b.Property<int>("EntidadesId")
                        .HasColumnType("int");

                    b.Property<int>("LocalizacionesId")
                        .HasColumnType("int");

                    b.HasKey("EntidadesId", "LocalizacionesId");

                    b.HasIndex("LocalizacionesId");

                    b.ToTable("EntidadLocalizacion");
                });

            modelBuilder.Entity("EntidadOrganismo", b =>
                {
                    b.Property<int>("EntidadesId")
                        .HasColumnType("int");

                    b.Property<int>("OrganismosId")
                        .HasColumnType("int");

                    b.HasKey("EntidadesId", "OrganismosId");

                    b.HasIndex("OrganismosId");

                    b.ToTable("EntidadOrganismo");
                });

            modelBuilder.Entity("EntidadPersona", b =>
                {
                    b.Property<int>("EntidadesInteresadasId")
                        .HasColumnType("int");

                    b.Property<int>("PersonasId")
                        .HasColumnType("int");

                    b.HasKey("EntidadesInteresadasId", "PersonasId");

                    b.HasIndex("PersonasId");

                    b.ToTable("EntidadPersona");
                });

            modelBuilder.Entity("EntidadSuperServicio", b =>
                {
                    b.Property<int>("EntidadesId")
                        .HasColumnType("int");

                    b.Property<int>("ServiciosId")
                        .HasColumnType("int");

                    b.HasKey("EntidadesId", "ServiciosId");

                    b.HasIndex("ServiciosId");

                    b.ToTable("EntidadSuperServicio");
                });

            modelBuilder.Entity("PersonaSuperServicio", b =>
                {
                    b.Property<int>("InteresesId")
                        .HasColumnType("int");

                    b.Property<int>("PersonasId")
                        .HasColumnType("int");

                    b.HasKey("InteresesId", "PersonasId");

                    b.HasIndex("PersonasId");

                    b.ToTable("PersonaSuperServicio");
                });

            modelBuilder.Entity("ServicioServicioAgrupado", b =>
                {
                    b.Property<int>("AgrupacionesId")
                        .HasColumnType("int");

                    b.Property<int>("ServiciosId")
                        .HasColumnType("int");

                    b.HasKey("AgrupacionesId", "ServiciosId");

                    b.HasIndex("ServiciosId");

                    b.ToTable("ServiciosPorGrupos", (string)null);
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Comunidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdministradorId")
                        .HasColumnType("int");

                    b.Property<int>("CantidadMiembrosAfectados")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AdministradorId");

                    b.ToTable("Comunidades");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Entidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoEntidad")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Entidades");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Establecimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UbicacionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UbicacionId");

                    b.ToTable("Establecimiento");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.FechasNotificacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.ToTable("FechasNotificacion");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Incidente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaApertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaCierre")
                        .HasColumnType("datetime2");

                    b.Property<string>("Informe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocalizacionId")
                        .HasColumnType("int");

                    b.Property<int?>("ProveedorId")
                        .HasColumnType("int");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocalizacionId");

                    b.HasIndex("ProveedorId");

                    b.HasIndex("ServicioId");

                    b.ToTable("Incidentes");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Localizacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoLocalizacion")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Localizaciones");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Medio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoMedio")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Medios");

                    b.HasDiscriminator<int>("TipoMedio");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Organismo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EncargadoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoOrganismo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EncargadoId");

                    b.ToTable("Organismos");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Participacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ComunidadId")
                        .HasColumnType("int");

                    b.Property<int>("MedioId")
                        .HasColumnType("int");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.Property<int>("Rol")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ComunidadId");

                    b.HasIndex("MedioId");

                    b.HasIndex("PersonaId");

                    b.ToTable("Participaciones");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocalizacionActualId")
                        .HasColumnType("int");

                    b.Property<int?>("LocalizacionDeInteresId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocalizacionActualId");

                    b.HasIndex("LocalizacionDeInteresId");

                    b.ToTable("Persona");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Prestacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EstablecimientoId")
                        .HasColumnType("int");

                    b.Property<bool>("Habilitado")
                        .HasColumnType("bit");

                    b.Property<int>("ServicioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstablecimientoId");

                    b.HasIndex("ServicioId");

                    b.ToTable("Prestacion");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.ProveedorDeServicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProveedorDeServicio");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Sucursal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EntidadId")
                        .HasColumnType("int");

                    b.Property<int>("EstablecimientoId")
                        .HasColumnType("int");

                    b.Property<int>("NumeroSucursal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EntidadId");

                    b.HasIndex("EstablecimientoId");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.SuperServicio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProveedorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProveedorId");

                    b.ToTable("SuperServicio", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("SuperServicio");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Ubicacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Latitud")
                        .HasColumnType("float");

                    b.Property<double>("Longitud")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Ubicacion");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("CorreoElectronico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonaId")
                        .HasColumnType("int");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId")
                        .IsUnique()
                        .HasFilter("[PersonaId] IS NOT NULL");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.entities.ServicioRanking.Ranking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Json")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoRanking")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rankings");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Correo", b =>
                {
                    b.HasBaseType("TPINTEGRADOR.Models.Medio");

                    b.HasDiscriminator().HasValue(2);
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Whatsapp", b =>
                {
                    b.HasBaseType("TPINTEGRADOR.Models.Medio");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Servicio", b =>
                {
                    b.HasBaseType("TPINTEGRADOR.Models.SuperServicio");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("SERVICIO");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.ServicioAgrupado", b =>
                {
                    b.HasBaseType("TPINTEGRADOR.Models.SuperServicio");

                    b.HasDiscriminator().HasValue("SERVICIOAGRUPADO");
                });

            modelBuilder.Entity("ComunidadIncidente", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Comunidad", null)
                        .WithMany()
                        .HasForeignKey("ComunidadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.Incidente", null)
                        .WithMany()
                        .HasForeignKey("IncidentesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ComunidadSuperServicio", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Comunidad", null)
                        .WithMany()
                        .HasForeignKey("ComunidadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.SuperServicio", null)
                        .WithMany()
                        .HasForeignKey("InteresesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntidadLocalizacion", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Entidad", null)
                        .WithMany()
                        .HasForeignKey("EntidadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.Localizacion", null)
                        .WithMany()
                        .HasForeignKey("LocalizacionesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntidadOrganismo", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Entidad", null)
                        .WithMany()
                        .HasForeignKey("EntidadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.Organismo", null)
                        .WithMany()
                        .HasForeignKey("OrganismosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntidadPersona", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Entidad", null)
                        .WithMany()
                        .HasForeignKey("EntidadesInteresadasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.Persona", null)
                        .WithMany()
                        .HasForeignKey("PersonasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EntidadSuperServicio", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Entidad", null)
                        .WithMany()
                        .HasForeignKey("EntidadesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.SuperServicio", null)
                        .WithMany()
                        .HasForeignKey("ServiciosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonaSuperServicio", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.SuperServicio", null)
                        .WithMany()
                        .HasForeignKey("InteresesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.Persona", null)
                        .WithMany()
                        .HasForeignKey("PersonasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ServicioServicioAgrupado", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.ServicioAgrupado", null)
                        .WithMany()
                        .HasForeignKey("AgrupacionesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.Servicio", null)
                        .WithMany()
                        .HasForeignKey("ServiciosId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Comunidad", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Persona", "Administrador")
                        .WithMany()
                        .HasForeignKey("AdministradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrador");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Establecimiento", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Ubicacion", "Ubicacion")
                        .WithMany()
                        .HasForeignKey("UbicacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ubicacion");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.FechasNotificacion", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Persona", "Persona")
                        .WithMany("HorariosParaNotificacion")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Incidente", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Localizacion", "Localizacion")
                        .WithMany()
                        .HasForeignKey("LocalizacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.ProveedorDeServicio", "Proveedor")
                        .WithMany("Incidentes")
                        .HasForeignKey("ProveedorId");

                    b.HasOne("TPINTEGRADOR.Models.SuperServicio", "Servicio")
                        .WithMany("Incidentes")
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Localizacion");

                    b.Navigation("Proveedor");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Organismo", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Persona", "Encargado")
                        .WithMany()
                        .HasForeignKey("EncargadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Encargado");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Participacion", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Comunidad", "Comunidad")
                        .WithMany("Miembros")
                        .HasForeignKey("ComunidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.Medio", "Medio")
                        .WithMany()
                        .HasForeignKey("MedioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.Persona", "Persona")
                        .WithMany("Participaciones")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comunidad");

                    b.Navigation("Medio");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Persona", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Localizacion", "LocalizacionActual")
                        .WithMany()
                        .HasForeignKey("LocalizacionActualId");

                    b.HasOne("TPINTEGRADOR.Models.Localizacion", "LocalizacionDeInteres")
                        .WithMany()
                        .HasForeignKey("LocalizacionDeInteresId");

                    b.Navigation("LocalizacionActual");

                    b.Navigation("LocalizacionDeInteres");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Prestacion", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Establecimiento", "Establecimiento")
                        .WithMany("Prestaciones")
                        .HasForeignKey("EstablecimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.SuperServicio", "Servicio")
                        .WithMany("Prestaciones")
                        .HasForeignKey("ServicioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Establecimiento");

                    b.Navigation("Servicio");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Sucursal", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Entidad", "Entidad")
                        .WithMany("Sucursales")
                        .HasForeignKey("EntidadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TPINTEGRADOR.Models.Establecimiento", "Establecimiento")
                        .WithMany("Sucursales")
                        .HasForeignKey("EstablecimientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entidad");

                    b.Navigation("Establecimiento");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.SuperServicio", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.ProveedorDeServicio", "Proveedor")
                        .WithMany("SuperServicio")
                        .HasForeignKey("ProveedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Usuario", b =>
                {
                    b.HasOne("TPINTEGRADOR.Models.Persona", "Persona")
                        .WithOne("Usuario")
                        .HasForeignKey("TPINTEGRADOR.Models.Usuario", "PersonaId");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Comunidad", b =>
                {
                    b.Navigation("Miembros");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Entidad", b =>
                {
                    b.Navigation("Sucursales");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Establecimiento", b =>
                {
                    b.Navigation("Prestaciones");

                    b.Navigation("Sucursales");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.Persona", b =>
                {
                    b.Navigation("HorariosParaNotificacion");

                    b.Navigation("Participaciones");

                    b.Navigation("Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.ProveedorDeServicio", b =>
                {
                    b.Navigation("Incidentes");

                    b.Navigation("SuperServicio");
                });

            modelBuilder.Entity("TPINTEGRADOR.Models.SuperServicio", b =>
                {
                    b.Navigation("Incidentes");

                    b.Navigation("Prestaciones");
                });
#pragma warning restore 612, 618
        }
    }
}