using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Soat.AntiGaspi.Application.UseCases.Offers
{
 
    public record CreateOfferCommand : IRequest<Guid>
    {
        public string Name;
        public string Description;

        public CreateOfferCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class CreateOffer : IRequestHandler<CreateOfferCommand, Guid>
    {
        public async Task<Guid> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
        {
            return Guid.NewGuid();
        }
    }   
}