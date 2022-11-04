using appRepubliquei.Domain;
using appRepubliquei.Domain.Commands;
using appRepubliquei.Domain.Entidades;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace apiRepubliquei.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ImovelController : Controller
    {
        private readonly IMediator _mediator;
        public ImovelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("InserirImovel")]
        public async Task<IActionResult> InserirImovel([FromBody] InserirImovelCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new Retorno<RetornoSimples>(string.Empty, result));
            }
            catch (Exception e)
            {
                return BadRequest(new Retorno<Usuario>(e.Message, null));
            }
        }
    }
}

