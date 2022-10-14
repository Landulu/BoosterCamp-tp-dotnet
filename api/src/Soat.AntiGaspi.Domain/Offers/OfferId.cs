namespace Soat.AntiGaspi.Domain.Offers;

public record OfferId
{
    public Guid Value;

    public OfferId(Guid value)
    {
        Value = value;
    }
}