using Microsoft.EntityFrameworkCore;
using Soat.Antigaspi.Infrastructure.repositories.Configurations;
using Soat.Antigaspi.Infrastructure.repositories.Entities;

namespace Soat.Antigaspi.Infrastructure.repositories
{
    public class AntiGaspiContext : DbContext
    {
        public const string DefaultSchema = "antigaspi";
        public DbSet<Offer> Offers { get; set; }

        public AntiGaspiContext()
        {
        }

        public AntiGaspiContext(DbContextOptions<AntiGaspiContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OffersTypeConfiguration());
        }

        
    }
}
