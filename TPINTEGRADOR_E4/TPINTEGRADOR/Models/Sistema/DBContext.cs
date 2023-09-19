using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;
using TPINTEGRADOR.Models;

namespace TPINTEGRADOR.Models.Sistema
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medio> Medios { get; set; }
        public DbSet<Comunidad> Comunidades { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<ServicioAgrupado> ServiciosAgrupados { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Servicio>()
                .HasMany(s1 => s1.Agrupaciones)
                .WithMany(s2 => s2.Servicios)
                .UsingEntity(j => j.ToTable("ServiciosPorGrupos"));

            modelBuilder.Entity<Medio>()
                .HasDiscriminator<int>("TipoMedio")
                .HasValue<Whatsapp>(1)
                .HasValue<Correo>(2);

            modelBuilder.Entity<Comunidad>()
               .HasOne(c => c.Administrador)
               .WithMany()
               .HasForeignKey(p => p.AdministradorId)
               .OnDelete(DeleteBehavior.NoAction); // Cambia la regla de cascada

            modelBuilder.Entity<Persona>()
               .HasOne(p => p.LocalizacionDeInteres)
               .WithMany()
               .HasForeignKey(p => p.LocalizacionDeInteresId)
               .OnDelete(DeleteBehavior.NoAction); // Cambia la regla de cascada

            modelBuilder.Entity<Persona>()
               .HasOne(p => p.LocalizacionActual)
               .WithMany()
               .HasForeignKey(p => p.LocalizacionActualId)
               .OnDelete(DeleteBehavior.NoAction); // Cambia la regla de cascada

            modelBuilder.Entity<Incidente>()
               .HasOne(p => p.Proveedor)
               .WithMany()
               .HasForeignKey(p => p.ProveedorId)
               .OnDelete(DeleteBehavior.NoAction); // Cambia la regla de cascada

            base.OnModelCreating(modelBuilder);
        }
    }
}
