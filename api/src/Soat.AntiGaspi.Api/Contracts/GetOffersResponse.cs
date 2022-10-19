namespace Soat.AntiGaspi.Api.Contracts;

public class GetOffersResponse
{
    public ICollection<GetOfferResponse> Offers { get; init; } = new List<GetOfferResponse>();
}