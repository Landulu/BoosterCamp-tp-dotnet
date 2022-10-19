using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Soat.AntiGaspi.Api.Contracts;
using Soat.AntiGaspi.Api.Repository;
using Soat.Antigaspi.Application.UseCases.Offers;
using Soat.Antigaspi.Infrastructure.repositories;

namespace Soat.AntiGaspi.Api.Controllers
{
    [ApiController]
    public class OffersController : ApiControllerBase
    {
        private readonly ILogger<OffersController> _logger;
        private readonly AntiGaspiContext _antiGaspiContext;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        

        public OffersController(
            AntiGaspiContext antiGaspiContext,
            IMapper mapper,
            IConfiguration configuration,
            ILogger<OffersController> logger)
        {
            _logger = logger;
            _antiGaspiContext = antiGaspiContext;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetOfferResponse>> Get(Guid id)
        {
            var offer = await Mediator.Send(new GetOfferQuery(id));
            return Ok(GetOfferResponse.From(offer));
        }
        
        [HttpGet]
        public async Task<ActionResult<GetOffersResponse>> GetAll()
        {
            var offers = await Mediator.Send(new GetOffersQuery());
            return Ok(new GetOffersResponse()
            {
                Offers = offers.Offers.Select( GetOfferResponse.From).ToList()
            });
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateOfferRequest createOfferRequest)
        {
            
            CreateOfferCommand offer = _mapper.Map<CreateOfferCommand>(createOfferRequest);

            var offerId = await Mediator.Send(offer);

            return CreatedAtAction(nameof(Get), new { id = offerId }, offerId);
        }
    }
}