namespace Soat.AntiGaspi.Domain.Offers.dtos;

public class OfferReadDto
{
    public OfferReadDto(Guid id, string title, string description, string address, string email, string companyName, DateTimeOffset? availability, DateTimeOffset? expiration, OfferStatus status)
    {
        Id = id;
        Title = title;
        Description = description;
        Address = address;
        Email = email;
        CompanyName = companyName;
        Availability = availability;
        Expiration = expiration;
        Status = status;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string CompanyName { get; set; }
    public DateTimeOffset? Availability { get; set; }
    public DateTimeOffset? Expiration { get; set; }
    public OfferStatus Status { get; set; }

    public Offer ToDomain()
    {
        return new Offer(new OfferId(Id), Title, Description, Email, CompanyName, Address, Availability,
            Expiration, Status);
    }
}