using System.Reflection;
using AutoMapper;
using MediatR;
using Soat.Antigaspi.Application.UseCases.dtos;
using Soat.AntiGaspi.Domain.Offers;

namespace Soat.Antigaspi.Application.UseCases.Offers;

public class CreateOfferCommand : IRequest<CreatedResponse>
{
    public Guid Id { get; set; }

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

public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, CreatedResponse>
{
    
    private readonly IOffers _offers;
    
    private readonly IMapper _mapper;

    public CreateOfferCommandHandler( IMapper mapper, IOffers offers)
    {
        _mapper = mapper;
        _offers = offers;
    }

    public async Task<CreatedResponse> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
    {
        var id = _offers.GetNextId();
        var newOffer = new OfferWriteDto(
            id, 
            request.Title, 
            request.Description, 
            request.Address, 
            request.Email, 
            request.CompanyName, 
            request.Availability, 
            request.Expiration, 
            request.Status);
        
        _offers.Add(newOffer);
        await _offers.SaveChangesAsync();

        return new CreatedResponse()
        {
            Id = id
        };
    }
}