using Microsoft.EntityFrameworkCore;

namespace DockerGymApp.Service.Entities
{
    public class GymAppPaymentServiceDbContext : DbContext
    {
        public GymAppPaymentServiceDbContext(DbContextOptions<GymAppPaymentServiceDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymAppPaymentServiceDbContext).Assembly);
            modelBuilder.Entity<Payments>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Payments> Payments { get; set; }
    }
}
