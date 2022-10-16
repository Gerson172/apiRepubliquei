using appRepubliquei.Domain.Commands;
using appRepubliquei.Domain.Contracts.Services;
using appRepubliquei.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace appRepubliquei.Application.CommandHandlers
{
    public class UsuarioCommandHandler : IRequestHandler<ObterUsuarioPorIdCommand, Usuario> 
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public async Task<Usuario> Handle(ObterUsuarioPorIdCommand request, CancellationToken cancellationToken)
        {
            return await _usuarioService.ObterUsuarioPorId(request.IdUsuario);
        }
    }
}
