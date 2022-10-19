
using Soat.AntiGaspi.Domain.Offers;
using Soat.AntiGaspi.Domain.Offers.dtos;
using Offer = Soat.Antigaspi.Infrastructure.repositories.Entities.Offer;

namespace Soat.Antigaspi.Infrastructure.repositories.Repositories;

public class OffersRepository : IOffers
{

    private readonly AntiGaspiContext _context;

    public OffersRepository(AntiGaspiContext context)
    {
        _context = context;
    }
    
    private DateTimeOffset ToLocale(DateTime dateTime)
    {
        return new DateTimeOffset(dateTime);
    }

    private DateTime ToGenericTime(DateTimeOffset dateTimeOffset)
    {
        return new DateTime(dateTimeOffset.UtcTicks);
    }

    private Offer ToDataEntity(OfferWriteDto writeDto)
    {
        return new Entities.Offer()
        {
            Id = writeDto.Id,
            Title = writeDto.Title,
            Description = writeDto.Description,
            Address = writeDto.Address,
            CompanyName = writeDto.CompanyName,
            Availability = writeDto.Availability is not null ? ToGenericTime(writeDto.Availability.Value) : null,
            Expiration = writeDto.Expiration is not null ? ToGenericTime(writeDto.Expiration.Value) : null,
            Email = writeDto.Email,
            Status = writeDto.Status

        };
    }

    public Guid GetNextId()
    {
        return Guid.NewGuid();
    }

    public async Task Insert(OfferWriteDto offer)
    {
        await _context.AddAsync(ToDataEntity(offer));
        await _context.SaveChangesAsync();
    }

    public async Task Update(OfferWriteDto offer)
    {
        _context.Update(ToDataEntity(offer));
        await _context.SaveChangesAsync();
    }

  

    public async Task<OfferReadDto> Get(Guid id)
    {
        var offer = await _context.Offers.FindAsync(id);

        if (offer is null)
        {
            throw new KeyNotFoundException($"offer with id {id} not found");
        } 
        
        return new OfferReadDto(
            offer.Id,
            offer.Title,
            offer.Description,
            offer.Address,
            offer.Email,
            offer.CompanyName,
            offer.Availability,
            offer.Expiration,
            offer.Status
        );
    }

    public async Task<ICollection<OfferReadDto>> GetAll()
    {
        var offers = _context.Offers
            .ToList().
            Select( o =>new OfferReadDto(
                o.Id,
                o.Title,
                o.Description,
                o.Address,
                o.Email,
                o.CompanyName,
                o.Availability,
                o.Expiration,
                o.Status
            )).ToList();

        return offers;

    }
}