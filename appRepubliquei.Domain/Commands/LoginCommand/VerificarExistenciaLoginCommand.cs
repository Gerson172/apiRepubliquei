using appRepubliquei.Domain.Entidades;
using MediatR;

namespace appRepubliquei.Domain.Commands.LoginCommand
{
    public class VerificarExistenciaLoginCommand : IRequest<vwExisteUsuario>
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
