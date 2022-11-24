using appRepubliquei.Domain.Commands;
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
        Task<RetornoSimples> CadastrarUsuario(CadastrarUsuarioCommand request);
        Task<IEnumerable<Usuario>> ObterUsuario(ObterUsuarioCommand request);
        Task<IEnumerable<vwUsuarioContato>> ObterUsuarioContato(ObterUsuarioContatoCommand request);
        Task<vwUsuarioContato> ObterUsuarioContatoPorId(ObterUsuarioContatoPorIdCommand request);

        //Task<RetornoSimples> AtualizarUsuario(AtualizarUsuarioCommand request);
    }
}
