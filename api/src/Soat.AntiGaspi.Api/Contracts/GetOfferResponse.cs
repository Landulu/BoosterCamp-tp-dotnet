using Soat.Antigaspi.Application.UseCases.dtos;

namespace Soat.AntiGaspi.Api.Contracts
{

    public class GetOfferResponse
    {
        
        public Guid Id { get; init; }
        public string? Title { get; init; }

        public string? Description { get; init; }

        public string? Email { get; init; }

        public string? CompanyName { get; init; }

        public string? Address { get; init; }

        public DateTimeOffset? Availability { get; init; }

        public DateTimeOffset? Expiration { get; init; }

        public static GetOfferResponse From(OfferResponse dto)
        {
            return new GetOfferResponse
            {
                Id = dto.Id,
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
    
    
}
