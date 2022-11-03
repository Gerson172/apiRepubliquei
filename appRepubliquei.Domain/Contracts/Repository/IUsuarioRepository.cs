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
        Task InserirEnderecoUsuario(int cep, string cidade, string bairro, string logradouro, string numero, string complemento);

        Task InserirContatoUsuario(string email, int celular, int? telefone);

        Task InserirCaracteristicaUsuario(string religiao, string genero, string sexo, string orientacaoSexual, string areaInteresse);

        Task InserirUsuario(string nome, string sobrenome, string senha, string cpf, string estadoCivil, DateTime dataNascimento);

        Task<EnderecoUsuario> ObterUltimoRegistroInserido();
        
        Task Exemplo();

        Task CrieiEssaAquiPorCima();
    }
}
