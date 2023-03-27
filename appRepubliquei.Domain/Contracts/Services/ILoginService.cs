using appRepubliquei.Domain.Commands.LoginCommand;
using appRepubliquei.Domain.Entidades;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Contracts.Services
{
    public interface ILoginService
    {
        Task<vwExisteUsuario> VerificarExistenciaLogin(VerificarExistenciaLoginCommand request);
    }
}
