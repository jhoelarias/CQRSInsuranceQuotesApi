namespace Coterie.Api.Controllers
{
    using Domain.Commands.QuoteCommands;
    using Domain.Responses;
    using Domain.Responses.Quote;
    using MediatR;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("[controller]")]
    public class QuotesController : CoterieBaseController
    {
        private readonly IMediator _mediator;

        public QuotesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            ;
        }

        [HttpPost]
        [Route("CalculateQuote")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenericResponse<CalculateQuoteResponse>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(GenericResponse<CalculateQuoteResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(GenericResponse<CalculateQuoteResponse>))]
        public async Task<IActionResult> CalculateQuote([FromBody] CalculateQuoteCommand query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}