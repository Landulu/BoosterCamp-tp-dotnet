using Soat.AntiGaspi.Domain.Offers;

namespace Soat.AntiGaspi.Api.Repository.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class OffersTypeConfiguration : IEntityTypeConfiguration<Offer>
{
    public void Configure(EntityTypeBuilder<Offer> builder)
    {
        builder.ToTable("Offers", AntiGaspiContext.DefaultSchema);
        builder.HasKey(x => x.Id);
    }
}
