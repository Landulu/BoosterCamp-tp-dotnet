using Soat.AntiGaspi.Domain.Offers.dtos;

namespace Soat.AntiGaspi.Domain.Offers;

public interface IOffers
{
    public Guid GetNextId();
    public Task Insert(OfferWriteDto offer);
    public Task Update(OfferWriteDto offer);
    public Task<OfferReadDto> Get(Guid id);
    public Task<ICollection<OfferReadDto>> GetAll();
}