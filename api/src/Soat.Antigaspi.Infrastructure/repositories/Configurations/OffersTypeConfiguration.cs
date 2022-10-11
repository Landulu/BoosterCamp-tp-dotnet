using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Soat.Antigaspi.Infrastructure.repositories.Entities;

namespace Soat.Antigaspi.Infrastructure.repositories.Configurations;

public class OffersTypeConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.ToTable("Offers", AntiGaspiContext.DefaultSchema);
        builder.HasKey(x => x.Id);
    }
}
