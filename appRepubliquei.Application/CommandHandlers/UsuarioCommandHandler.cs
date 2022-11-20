using appRepubliquei.Domain;
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
    public class UsuarioCommandHandler : IRequestHandler<ObterUsuarioPorIdCommand, Usuario>, 
                                         IRequestHandler<CadastrarUsuarioCommand, RetornoSimples>//,
                                         //IRequestHandler<AtualizarUsuarioCommand, RetornoSimples>
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
        public async Task<RetornoSimples> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            return await _usuarioService.CadastrarUsuario(request);
        }
        //public async Task<RetornoSimples> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        //{
        //    return await _usuarioService.AtualizarUsuario(request);
        //}
    }
}
