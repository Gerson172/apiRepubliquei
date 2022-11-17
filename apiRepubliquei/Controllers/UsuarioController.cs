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
    public class UsuarioController : Controller
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("ObterUsuarioPorId")]
        public async Task<IActionResult> ObterUsuarioPorId([FromQuery] ObterUsuarioPorIdCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new Retorno<Usuario>(string.Empty, result));
            }
            catch (Exception e)
            {
                return BadRequest(new Retorno<Usuario>(e.Message, null));
        
            }
        }

        [HttpPost("CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CadastrarUsuarioCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new Retorno<RetornoSimples>(string.Empty, result));
            }
            catch (Exception e)
            {
                return BadRequest(new Retorno<RetornoSimples>(e.Message, null));

            }
        }

        //[HttpPut("AtualizarUsuario")]
        //public async Task<IActionResult> AtualizarUsuario([FromBody] AtualizarUsuarioCommand command)
        //{
        //    try
        //    {
        //        var result = await _mediator.Send(command);
        //        return Ok(new Retorno<RetornoSimples>(string.Empty, result));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new Retorno<RetornoSimples>(e.Message, null));

        //}
        //    }

        //[HttpDelete("ExcluirUsuario")]
        //public async Task<IActionResult> ExcluirUsuario([FromBody] ExcluirUsuarioCommand command)
        //{
        //    try
        //    {
        //        var result = await _mediator.Send(command);
        //        return Ok(new Retorno<RetornoSimples>(string.Empty, result));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(new Retorno<RetornoSimples>(e.Message, null));

        //    }
        //}
    }
}
