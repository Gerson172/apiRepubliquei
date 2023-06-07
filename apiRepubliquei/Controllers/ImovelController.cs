using appRepubliquei.Domain;
using appRepubliquei.Domain.Commands.ImovelCommand;
using appRepubliquei.Domain.Entidades;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
                if (command.IdUsuario == null)
                {
                    command.IdUsuario = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userId").Value);
                }
                var result = await _mediator.Send(command);
                return Ok(new Retorno<RetornoSimples>(string.Empty, result));
            }
            catch (Exception e)
            {
                return BadRequest(new Retorno<Imovel>(e.Message, null));
            }
        }

        [HttpGet("ObterImovel")]
        public async Task<IActionResult> ObterImovel([FromQuery] ObterImovelCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new Retorno<IEnumerable<vwImovel>>(string.Empty, result));
            }
            catch (Exception e)
            {
                return BadRequest(new Retorno<Imovel>(e.Message, null));
            }
        }
        [HttpGet("ObterImovelPorId")]
        public async Task<IActionResult> ObterImovelPorId([FromQuery] ObterImovelPorIdCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new Retorno<vwImovel>(string.Empty, result));
            }
            catch (Exception e)
            {
                return BadRequest(new Retorno<Imovel>(e.Message, null));
            }
        }

        [Authorize]
        [HttpGet("ObterImovelPorUsuarioId")]
        public async Task<IActionResult> ObterImovelPorUsuarioId([FromQuery] ObterImovelPorUsuarioIdCommand command)
        {
            try
            {
                if (command.IdUsuario == null)
                {
                    command.IdUsuario = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userId").Value);
                }
                var result = await _mediator.Send(command);
                return Ok(new Retorno<IEnumerable<vwImovel>>(string.Empty, result));
            }
            catch (Exception e)
            { 
                return BadRequest(new Retorno<Imovel>(e.Message, null));
            }
        }

        [Authorize]
        [HttpDelete("DeletarImovelPorId")]
        public async Task<IActionResult> DeletarImovelPorId([FromQuery] DeletarImovelPorIdCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new Retorno<RetornoSimples>(string.Empty, result));
            }
            catch (Exception e)
            {
                return BadRequest(new Retorno<Imovel>(e.Message, null));
            }
        }

        [HttpPut("AtualizarImovel")]
        public async Task<IActionResult> AtualizarImovel([FromBody] AtualizarImovelCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new Retorno<RetornoSimples>(string.Empty, result));
            }
            catch (Exception e)
            {
                return BadRequest(new Retorno<Imovel>(e.Message, null));
            }
        }
    }
}

