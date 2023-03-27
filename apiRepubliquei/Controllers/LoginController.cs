using appRepubliquei.Domain;
using appRepubliquei.Domain.Commands.LoginCommand;
using appRepubliquei.Domain.Commands.UsuarioCommand;
using appRepubliquei.Domain.Entidades;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace apiRepubliquei.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("RealizarLogin")]
        public async Task<IActionResult> RealizarLogin([FromBody] VerificarExistenciaLoginCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                return Ok(new Retorno<vwExisteUsuario>(string.Empty, result));
            }
            catch (Exception e)
            {
                return BadRequest(new Retorno<Usuario>(e.Message, null));

            }
        }
    }
}
