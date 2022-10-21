using Soat.AntiGaspi.Domain.Offers;

namespace Soat.AntiGaspi.Domain.Offers;
public class Offer
{
    public OfferId Id { get; }

    public string Title { get; private set; }

    public string Description { get; private set; } 

    public string Email { get; private set; }

    public string CompanyName { get; private set; }

    public string Address { get; private set; } 

    public DateTimeOffset? Availability { get; private set; }

    public DateTimeOffset? Expiration { get; private set; }

    public OfferStatus Status { get; private set; }

    public Offer(OfferId id, string title, string description, string email, string companyName, string address, DateTimeOffset? availability, DateTimeOffset? expiration, OfferStatus status)
    {
        Id = id;
        Title = title;
        Description = description;
        Email = email;
        CompanyName = companyName;
        Address = address;
        Availability = availability;
        Expiration = expiration;
        Status = status;
    }

    public static Result<Offer> CreateNew(OfferId id, string title, string description, string email,
        string companyName, string address,
        DateTimeOffset? availability, DateTimeOffset? expiration, DateTimeOffset now)
    {
        if (expiration < now)
        {
            return new Result<Offer>(error: "expiration_passed_on_creation");
        }

        var offer = new Offer(
            id,
            title,
            description,
            email,
            companyName,
            address,
            availability,
            expiration,
            OfferStatus.Pending);
        return new Result<Offer>(value: offer);
    }


    public Result<Offer> Activate(DateTimeOffset now)
    {
        if (Status != OfferStatus.Pending)
        {
            return new Result<Offer>(error: "cannot_activate_not_pending_offer");
        }

        
        if (Expiration < now)
        {
            return new Result<Offer>(error: "cannot_activate_already_expired_offer");
        }

        Status = OfferStatus.Active;

        return new Result<Offer>(value: this);


    }

    public Result<Offer> CanDelete()
    {
        
        return new Result<Offer>(value: this);

    }
}   