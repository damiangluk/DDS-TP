using Microsoft.EntityFrameworkCore;
using TPINTEGRADOR.Models.entities.ServicioRanking;

namespace TPINTEGRADOR.Models.Sistema
{
    public class DBContext : DbContext
    {
        private static IConfiguration _configuration;

        public DBContext(DbContextOptions<DBContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Medio> Medios { get; set; }
        public DbSet<Comunidad> Comunidades { get; set; }
        public DbSet<Entidad> Entidades { get; set; }
        public DbSet<Incidente> Incidentes { get; set; }
        public DbSet<Ranking> ImpactoIncidentes { get; set; }
        public DbSet<Participacion> Participaciones { get; set; }
        public DbSet<Organismo> Organismos { get; set; }
        public DbSet<SuperServicio> SuperServicios { get; set; }
        public DbSet<Localizacion> Localizaciones { get; set; }

        public static DBContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DBContext>();
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Conexion"));
            return new DBContext(optionsBuilder.Options, _configuration);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }


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

            modelBuilder.Entity<SuperServicio>().ToTable("SuperServicio")
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Servicio>("SERVICIO")
                .HasValue<ServicioAgrupado>("SERVICIOAGRUPADO");
            base.OnModelCreating(modelBuilder);
        }
    }
}
