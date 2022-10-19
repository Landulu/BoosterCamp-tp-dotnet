using System.Reflection;
using AutoMapper;
using MediatR;
using Soat.Antigaspi.Application.UseCases.Contracts.Services;
using Soat.Antigaspi.Application.UseCases.dtos;
using Soat.AntiGaspi.Domain;
using Soat.AntiGaspi.Domain.Offers;
using Soat.AntiGaspi.Domain.Offers.dtos;

namespace Soat.Antigaspi.Application.UseCases.Offers;

public class CreateOfferCommand : IRequest<Result<OfferResponse>>
{
    
    public string Title { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string CompanyName { get; set; } = default!;

    public string Address { get; set; } = default!;

    public DateTime? Availability { get; set; }

    public DateTime? Expiration { get; set; }

    public AntiGaspi.Domain.Offers.OfferStatus Status { get; set; }
}

public enum OfferStatus
{
    Pending,
    Active,
    Expired,
    Deleted
}

public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, Result<OfferResponse>>
{
    
    private readonly IOffers _offers;
    
    private readonly IMapper _mapper;
    private readonly ITimeProvider _timeProvider;

    public CreateOfferCommandHandler( IMapper mapper, IOffers offers, ITimeProvider timeProvider)
    {
        _mapper = mapper;
        _offers = offers;
        _timeProvider = timeProvider;
    }

    public async Task<Result<OfferResponse>> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
    {
        var id = _offers.GetNextId();


        var offer = Offer.CreateNew(new OfferId(id),
            request.Title,
            request.Description,
            request.Email,
            request.CompanyName,
            request.Address,
            request.Availability,
            request.Expiration,
            _timeProvider.UtcNow());
        
        if (!offer.Success) return new Result<OfferResponse>(offer.Error);
        
        await _offers.Insert(OfferWriteDto.FromDomain(offer.Value));
            
        return new Result<OfferResponse>(OfferResponse.From(offer.Value));

    }
}