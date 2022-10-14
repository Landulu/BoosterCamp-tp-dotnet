namespace Soat.AntiGaspi.Domain.Offers.dtos;

public record OfferReadDto
{
    
    
    private Guid _id;
    private string _title;
    private string _description;

    public OfferReadDto(Guid id, string title, string description)
    {
        _id = id;
        _title = title;
        _description = description;
    }
}