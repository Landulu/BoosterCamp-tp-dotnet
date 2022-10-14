

using Soat.Antigaspi.Application.UseCases.Offers;

namespace Soat.AntiGaspi.Api.Contracts.Profiles;

using AutoMapper;

public class OfferAutoMapperProfile : Profile
{
    public OfferAutoMapperProfile()
    {
        CreateMap<CreateOfferRequest, CreateOfferCommand>();
        //CreateMap<CreateOfferCommand, GetOfferResponse>();
    }
}
