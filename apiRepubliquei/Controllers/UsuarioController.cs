using appRepubliquei.Domain;
using appRepubliquei.Domain.Commands.UsuarioCommand;
using appRepubliquei.Domain.Entidades;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        [HttpGet("ObterUsuario")]
        public async Task<IActionResult> ObterUsuario([FromQuery] ObterUsuarioCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new Retorno<IEnumerable<Usuario>>(string.Empty, result));
            }
            catch (Exception e)
            {
                return BadRequest(new Retorno<Usuario>(e.Message, null));

            }
        }

        [HttpGet("ObterUsuarioPorId")]
        public async Task<IActionResult> ObterUsuarioPorId([FromQuery] ObterUsuarioPorIdCommand command)
        {
            try
            {
                if(command.IdUsuario == null)
                {
                    command.IdUsuario = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userId").Value);
                }

                var result = await _mediator.Send(command);
                return Ok(new Retorno<Usuario>(string.Empty, result));
            }
            catch (Exception e)
            {
                return BadRequest(new Retorno<Usuario>(e.Message, null));

            }
        }

        [HttpGet("ObterUsuarioContato")]
        public async Task<IActionResult> ObterUsuarioContato([FromQuery] ObterUsuarioContatoCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new Retorno<IEnumerable<vwUsuarioContato>>(string.Empty, result));
            }
            catch (Exception e)
            {
                return BadRequest(new Retorno<Usuario>(e.Message, null));

            }
        }

        [Authorize]
        [HttpGet("ObterUsuarioContatoPorId")]
        public async Task<IActionResult> ObterUsuarioContatoPorId([FromQuery] ObterUsuarioContatoPorIdCommand command)
        {
            try
            {
                if (command.IdUsuario == null)
                {
                    command.IdUsuario = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userId").Value);
                }

                var result = await _mediator.Send(command);
                return Ok(new Retorno<vwUsuarioContato>(string.Empty, result));
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

        [Authorize]
        [HttpPut("AtualizarUsuario")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] AtualizarUsuarioCommand command)
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
                return BadRequest(new Retorno<RetornoSimples>(e.Message, null));

            }
        }

        [Authorize]
        [HttpDelete("ExcluirUsuarioPorId")]
        public async Task<IActionResult> ExcluirUsuarioPorId([FromQuery] ExcluirUsuarioPorIdCommand command)
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
                return BadRequest(new Retorno<RetornoSimples>(e.Message, null));

            }
        }
    }
}
