using appRepubliquei.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Contracts.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterUsuarioPorId(int id);
    }
}
