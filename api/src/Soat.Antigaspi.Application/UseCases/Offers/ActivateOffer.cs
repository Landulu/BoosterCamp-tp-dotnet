using MediatR;
using Soat.Antigaspi.Application.UseCases.Contracts.Services;
using Soat.Antigaspi.Application.UseCases.dtos;
using Soat.AntiGaspi.Domain;
using Soat.AntiGaspi.Domain.Offers;
using Soat.AntiGaspi.Domain.Offers.dtos;

namespace Soat.Antigaspi.Application.UseCases.Offers;

public class ActivateOfferCommand: IRequest<Result<OfferResponse>>
{
    
    public Guid Id { get; set; }
    
}

public class ActivateOfferCommandHandler : IRequestHandler<ActivateOfferCommand, Result<OfferResponse>>
{
    private readonly IOffers _offers;
    private readonly ITimeProvider _time;

    public ActivateOfferCommandHandler(IOffers offers, ITimeProvider time)
    {
        _offers = offers;
        _time = time;
    }

    public async Task<Result<OfferResponse>> Handle(ActivateOfferCommand request, CancellationToken cancellationToken)
    {
        var dto = await _offers.Get(request.Id);
        var offer = dto.ToDomain().Activate(_time.UtcNow());

        if (!offer.Success) return new Result<OfferResponse>(offer.Error);
        
        await _offers.Update(OfferWriteDto.FromDomain(offer.Value));

        return new Result<OfferResponse>(OfferResponse.From(offer.Value));

    }
}