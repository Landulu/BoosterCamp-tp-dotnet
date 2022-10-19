using MediatR;
using Soat.Antigaspi.Application.UseCases.dtos;
using Soat.AntiGaspi.Domain.Offers;

namespace Soat.Antigaspi.Application.UseCases.Offers;

public class GetOffersQuery: IRequest<OffersResponse>
{
    public int Limit { get; set; }
}

public class GetOffersQueryHandler: IRequestHandler<GetOffersQuery, OffersResponse>
{
    private readonly IOffers _offers;

    public GetOffersQueryHandler(IOffers offers)
    {
        _offers = offers;
    }


    public async Task<OffersResponse> Handle(GetOffersQuery request, CancellationToken cancellationToken)
    {
        var offers = await _offers.GetAll();

        return new OffersResponse(offers.Select(o => OfferResponse.From(o.ToDomain())));

    }
}
