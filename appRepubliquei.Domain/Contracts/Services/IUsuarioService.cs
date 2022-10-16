using appRepubliquei.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Contracts.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> ObterUsuarioPorId(int idUsuario);
    }
}
