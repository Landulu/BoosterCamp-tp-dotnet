using Microsoft.EntityFrameworkCore;
using Soat.AntiGaspi.Api.Repository.Configurations;
using Soat.AntiGaspi.Domain.Offers;

namespace Soat.AntiGaspi.Api.Repository
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

        public Guid GetNextId()
        {
            return Guid.NewGuid();
        }
    }
}
