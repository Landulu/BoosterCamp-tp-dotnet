using System.Reflection;
using AutoMapper;
using MediatR;
using Soat.AntiGaspi.Api.Repository;
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

    public OfferStatus Status { get; set; }
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
    
    private readonly AntiGaspiContext _antiGaspiContext;
    
    private readonly IMapper _mapper;

    public CreateOfferCommandHandler(AntiGaspiContext antiGaspiContext, IMapper mapper)
    {
        _antiGaspiContext = antiGaspiContext;
        _mapper = mapper;
    }

    public async Task<CreatedResponse> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
    {
        var id = _antiGaspiContext.GetNextId();
        var newOffer = new Offer();
        newOffer.Id = id;
        newOffer.Address = request.Address;
        newOffer.Availability = request.Availability;
        newOffer.Description = request.Description;
        newOffer.Title = request.Title;
        newOffer.Email = request.Email;
        newOffer.CompanyName = request.CompanyName;
        newOffer.Status = (AntiGaspi.Domain.Offers.OfferStatus)request.Status;
        
        _antiGaspiContext.Add(newOffer);
        await _antiGaspiContext.SaveChangesAsync();

        return new CreatedResponse()
        {
            Id = id
        };
    }
}