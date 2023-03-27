using appRepubliquei.Domain;
using appRepubliquei.Domain.Commands.UsuarioCommand;
using appRepubliquei.Domain.Contracts.Services;
using appRepubliquei.Domain.Entidades;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace appRepubliquei.Application.CommandHandlers
{
    public class UsuarioCommandHandler : IRequestHandler<ObterUsuarioPorIdCommand, Usuario>, 
                                         IRequestHandler<CadastrarUsuarioCommand, RetornoSimples>,
                                         IRequestHandler<ObterUsuarioCommand, IEnumerable<Usuario>>,
                                         IRequestHandler<ObterUsuarioContatoCommand, IEnumerable<vwUsuarioContato>>,
                                         IRequestHandler<ObterUsuarioContatoPorIdCommand, vwUsuarioContato>//,
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
        public async Task<IEnumerable<Usuario>> Handle(ObterUsuarioCommand request, CancellationToken cancellationToken)
        {
            return await _usuarioService.ObterUsuario(request);
        }
        public async Task<IEnumerable<vwUsuarioContato>> Handle(ObterUsuarioContatoCommand request, CancellationToken cancellationToken)
        {
            return await _usuarioService.ObterUsuarioContato(request);
        }
        public async Task<vwUsuarioContato> Handle(ObterUsuarioContatoPorIdCommand request, CancellationToken cancellationToken)
        {
            return await _usuarioService.ObterUsuarioContatoPorId(request);
        }
        //public async Task<RetornoSimples> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        //{
        //    return await _usuarioService.AtualizarUsuario(request);
        //}
    }
}
