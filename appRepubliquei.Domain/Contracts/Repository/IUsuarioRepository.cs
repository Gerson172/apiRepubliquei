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
        Task<Usuario> ObterUsuarioPorId(int? id);
        Task InserirEnderecoUsuario(int cep, string estado, string cidade, string bairro, string logradouro, string numero, string complemento);
        Task InserirContatoUsuario(string email, string celular, string telefone);
        Task InserirCaracteristicaUsuario(string religiao, string genero, string sexo, string orientacaoSexual, string areaInteresse);
        Task InserirUsuario(string nome, string sobrenome, string senha, string cpf, string estadoCivil, DateTime dataNascimento,bool checkProprietario, bool checkTermos, int fkEnderecoUsuario,int fkContato,int fkCaracteristicaUsuario);
        Task<EnderecoUsuario> ObterUltimoRegistroInseridoUsuario();
        Task<Contato> ObterUltimoRegistroInseridoContatoUsuario();
        Task<IEnumerable<Usuario>> ObterUsuario();

        Task<vwUsuarioPorEmail> ObterUsuarioPorEmail(string email);
        Task<CaracteristicaUsuario> ObterUltimoRegistroInseridoCaracteristicaUsuario();
        Task<IEnumerable<vwUsuarioContato>> ObterUsuarioContato();
        Task<vwUsuarioContato> ObterUsuarioContatoPorId(int? idUsuario);
        bool VerificarEmailCpf(string email, string cpf);
        bool VerificarEmail(string email);

        Task InserirTokenUsuario(string email, string token);
        Task<vwExisteUsuario> VerificarExistenciaLogin(string email, string senha);
        Task ExcluirUsuarioPorId(int? idUsuario);
        Task<vwUsuarioToken> ObterTokenPorEmail(string email);
        Task AtualizarSenhaNova(string novaSenha, string email);
        Task AtualizarConfirmacaoEmail(string email);
    }
}
