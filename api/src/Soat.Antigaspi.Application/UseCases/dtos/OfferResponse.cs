using Soat.AntiGaspi.Domain.Offers;

namespace Soat.Antigaspi.Application.UseCases.dtos;

public class OfferResponse
{
    public Guid Id { get; init; }
    
    public string? Title { get; init; }

    public string? Description { get; init; }

    public string? Email { get; init; }

    public string? CompanyName { get; init; }

    public string? Address { get; init; }

    public DateTime? Availability { get; init; }

    public DateTime? Expiration { get; init; }
    
    public static OfferResponse From(Offer dto)
    {
        return new OfferResponse()
        {
            Id = dto.Id.Value,
            Title = dto.Title,
            Description = dto.Description,
            Email = dto.Email,
            CompanyName = dto.CompanyName,
            Address = dto.Address,
            Availability = dto.Availability,
            Expiration = dto.Expiration
        };
    }

}