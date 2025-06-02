using Microsoft.EntityFrameworkCore;
using Oper.Admision.Domain.Models;

namespace Oper.Admision.Infrastructure
{
    public class GestionContext : DbContext
    {
        private string? conexion;
        public DbSet<Sesion> Sesion {  get; set; } = null!;
        public DbSet<Socio> Socios { get; set; } = null!;
        public DbSet<Visita> Visita { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Problematico> Problematicos { get; set; }
        public DbSet<ProblematicoVista> ProblematicoVista { get; set; }


        public GestionContext() : base()
        {
            this.conexion = "server=localhost;user id=root;password=danielovik;persistsecurityinfo=True;database=oper_canaletico;Convert Zero Datetime=True ";
        }

        public GestionContext(string conexion) : base()
        {
            this.conexion = conexion;
        }

        public GestionContext(DbContextOptions<GestionContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de la relación entre Rol y Usuario
            modelBuilder.Entity<Rol>()
                .HasMany(r => r.Usuarios)
                .WithOne(u => u.Rol)
                .HasForeignKey(u => u.RolId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Rol)
                .WithMany(r => r.Usuarios)
                .HasForeignKey(u => u.RolId);

            //Configuración de los problmáticos.
            modelBuilder.Entity<ProblematicoVista>().HasNoKey().ToView(null);

        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured && !string.IsNullOrEmpty(this.conexion))
            {
                optionsBuilder
                    .UseMySql(this.conexion, new MySqlServerVersion(new Version(5, 7, 11)));
            }
        }

        public void DetachAllEntities()
        {
            var changedEntriesCopy = this.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

    }
}
