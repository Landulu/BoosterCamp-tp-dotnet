using System;

namespace Soat.AntiGaspi.Domaine.Offers;
public class Offer
{
    public OfferId Id { get; }

    public string Title { get; private set; }

    public string Description { get; private set; } 

    public string Email { get; private set; }

    public string CompanyName { get; private set; }

    public string Address { get; private set; } 

    public DateTime? Availability { get; private set; }

    public DateTime? Expiration { get; private set; }

    public OfferStatus Status { get; private set; }

    private Offer(OfferId id, string title, string description, string email, string companyName, string address, DateTime? availability, DateTime? expiration, OfferStatus status)
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

    public Offer CreateNew(OfferId id, string title, string description, string email, string companyName, string address,
        DateTime? availability, DateTime? expiration)
    {
        return new Offer(
            id, 
            title, 
            description, 
            email, 
            companyName, 
            address, 
            availability, 
            expiration,
            OfferStatus.Pending);
    }
    
    
}   