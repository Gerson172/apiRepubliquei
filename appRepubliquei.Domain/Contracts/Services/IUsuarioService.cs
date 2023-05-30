using appRepubliquei.Domain.Commands.UsuarioCommand;
using appRepubliquei.Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Contracts.Services
{
    public interface IUsuarioService
    {
        Task<Usuario> ObterUsuarioPorId(int? idUsuario);
        Task<RetornoSimples> CadastrarUsuario(CadastrarUsuarioCommand request);
        Task<IEnumerable<Usuario>> ObterUsuario(ObterUsuarioCommand request);
        Task<IEnumerable<vwUsuarioContato>> ObterUsuarioContato(ObterUsuarioContatoCommand request);
        Task<vwUsuarioContato> ObterUsuarioContatoPorId(ObterUsuarioContatoPorIdCommand request);
        Task<RetornoSimples> ExcluirUsuarioPorId(ExcluirUsuarioPorIdCommand request);
        Task<RetornoSimples> SolicitarAlteracao(SolicitarAlteracaoCommand request);
        Task<RetornoSimples> RedefinirSenha(ResetarSenhaCommand request);
        //Task<RetornoSimples> AtualizarUsuario(AtualizarUsuarioCommand request);
    }
}
