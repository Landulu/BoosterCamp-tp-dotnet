using MediatR;
using Soat.Antigaspi.Application.UseCases.dtos;
using Soat.AntiGaspi.Domain.Offers;

namespace Soat.Antigaspi.Application.UseCases.Offers;

public class GetOfferQuery: IRequest<OfferResponse>
{
    public Guid Id { get; set; }
}

public class GetOfferQueryHandler : IRequestHandler<GetOfferQuery, OfferResponse>
{

    private readonly IOffers _offers;

    public GetOfferQueryHandler(IOffers offers)
    {
        _offers = offers;
    }

    public async Task<OfferResponse> Handle(GetOfferQuery request, CancellationToken cancellationToken)
    {
        var offer = await _offers.Get(request.Id);
        
        return OfferResponse.From(offer.ToDomain());
        
    }
}