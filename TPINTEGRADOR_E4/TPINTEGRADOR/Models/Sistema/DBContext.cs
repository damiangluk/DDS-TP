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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medio>()
            .HasDiscriminator<int>("TipoMedio")
            .HasValue<Whatsapp>(1)
            .HasValue<Correo>(2);
            

            // modelBuilder.Entity<Medio>()
            //.HasDiscriminator<string>("TipoMedio")
            //.HasValue<Whatsapp>("WhatsApp")
            //.HasValue<Correo>("Correo");


            modelBuilder.Entity<Participacion>()
               .HasOne(p => p.Persona)
               .WithMany()
               .HasForeignKey(p => p.PersonaId)
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


            base.OnModelCreating(modelBuilder);
        }
    }
}
