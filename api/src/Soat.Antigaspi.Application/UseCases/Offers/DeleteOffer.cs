using MediatR;
using Soat.Antigaspi.Application.UseCases.dtos;
using Soat.AntiGaspi.Domain;
using Soat.AntiGaspi.Domain.Offers;
using Soat.AntiGaspi.Domain.Offers.dtos;

namespace Soat.Antigaspi.Application.UseCases.Offers;

public class DeleteOfferCommand:  IRequest<Result<OfferResponse>>
{
    public Guid Id { get; set; }
    
}

public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, Result<OfferResponse>>
{
    
    private readonly IOffers _offers;

    public DeleteOfferCommandHandler(IOffers offers)
    {
        _offers = offers;
    }

    public async Task<Result<OfferResponse>> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
    {
        
        var dto = await _offers.Get(request.Id);
        
        
        var offer = dto.ToDomain().CanDelete();
        
        
        if (!offer.Success) return new Result<OfferResponse>(offer.Error);

        
        await _offers.Delete(OfferWriteDto.FromDomain(offer.Value));
        
        
        return new Result<OfferResponse>(OfferResponse.From(offer.Value));
        
    }
}