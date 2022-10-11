using System;
using Soat.AntiGaspi.Domaine.Offers.dtos;

namespace Soat.AntiGaspi.Domaine.Offers;

public interface IOffers
{
    public Guid GetNextId();
    public void CreateOne(OfferWriteDto offer);
    public OfferReadDto GetOne(Guid id);
}