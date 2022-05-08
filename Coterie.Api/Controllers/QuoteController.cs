using Coterie.Domain.Responses;

namespace Coterie.Api.Controllers
{
    using Domain.Commands.QuoteCommands;
    using Domain.Responses.Quote;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class QuoteController : CoterieBaseController
    {
        private readonly IMediator _mediator;

        public QuoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("CalculateQuote")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CalculateQuoteResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiResponse<CalculateQuoteResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<CalculateQuoteResponse>))]
        public async Task<IActionResult> CalculateQuote([FromBody] CalculateQuoteCommand query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}