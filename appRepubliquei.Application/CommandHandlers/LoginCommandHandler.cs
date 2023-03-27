using appRepubliquei.Domain;
using appRepubliquei.Domain.Commands.ImovelCommand;
using appRepubliquei.Domain.Commands.LoginCommand;
using appRepubliquei.Domain.Contracts.Services;
using appRepubliquei.Domain.Entidades;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace appRepubliquei.Application.CommandHandlers
{
    public class LoginCommandHandler : IRequestHandler<VerificarExistenciaLoginCommand, vwExisteUsuario>
    {
        private readonly ILoginService _loginService;
        public LoginCommandHandler(ILoginService loginService)
        {
            _loginService = loginService;
        }
        public async Task<vwExisteUsuario> Handle(VerificarExistenciaLoginCommand request, CancellationToken cancellationToken)
        {
            return await _loginService.VerificarExistenciaLogin(request);
        }
    }
}
