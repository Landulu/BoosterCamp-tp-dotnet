namespace Soat.AntiGaspi.Domain.Offers.dtos;

public class OfferWriteDto
{
    public OfferWriteDto(Guid id, string description, string title, string address, string email, string companyName, DateTimeOffset? availability, DateTimeOffset? expiration, OfferStatus status)
    {
        Id = id;
        Description = description;
        Title = title;
        Address = address;
        Email = email;
        CompanyName = companyName;
        Availability = availability;
        Expiration = expiration;
        Status = status;
    }

    public static OfferWriteDto FromDomain(Offer offer)
    {
        return new OfferWriteDto(offer.Id.Value,
            offer.Description,
            offer.Title,
            offer.Address,
            offer.Email,
            offer.CompanyName,
            offer.Availability,
            offer.Expiration,
            offer.Status);
    }

    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Title { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string CompanyName { get; set; }
    public DateTimeOffset? Availability { get; set; }
    public DateTimeOffset? Expiration { get; set; }
    public OfferStatus Status { get; set; }
}
    