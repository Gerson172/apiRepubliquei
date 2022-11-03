using appRepubliquei.Domain.Contracts.Repository;
using appRepubliquei.Domain.Entidades;
using appRepubliquei.Infra.Data.Contexts;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace appRepubliquei.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlConnection _connection;
        public UsuarioRepository(IDatabaseContext context)
        {
            _connection = context.SqlConnection;
        }

        public async Task<Usuario> ObterUsuarioPorId(int idUsuario)
        {
            return await _connection.QueryFirstOrDefaultAsync<Usuario>(Queries.Queries.ObterUsuarioPorId,
                new
                {
                    IdUsuario = idUsuario
                });
        }

        public async Task InserirEnderecoUsuario(int cep, string cidade, string bairro, string logradouro, string numero, string complemento)
        {
            await _connection.ExecuteAsync(Queries.Queries.InserirEnderecoUsuario,
                new
                {
                    Cep = cep,
                    Cidade = cidade,
                    Bairro = bairro,
                    Logradouro = logradouro,
                    Numero = numero,
                    Complemento = complemento
                });
        }

        public async Task InserirContatoUsuario(string email, int celular, int? telefone = 0)
        {
            await _connection.ExecuteAsync(Queries.Queries.InserirContatoUsuario,
                new
                {
                    Email = email,
                    Celular = celular,
                    Telefone = telefone
                });
        }

        public async Task InserirCaracteristicaUsuario(string religiao, string genero, string sexo, string orientacaoSexual, string areaInteresse)
        {
            await _connection.ExecuteAsync(Queries.Queries.InserirCaracteristicaUsuario,
                new
                {
                    Religiao = religiao,
                    Genero = genero,
                    Sexo = sexo,
                    OrientacaoSexual = orientacaoSexual,
                    AreaInteresse = areaInteresse
                });
        }

        public async Task InserirUsuario(string nome, string sobrenome, string senha, string cpf, string estadoCivil, DateTime dataNascimento)
        {
            await _connection.ExecuteAsync(Queries.Queries.InserirUsuario,
                new
                {
                    Nome = nome,
                    Sobrenome = sobrenome,
                    Senha = senha,
                    Cpf = cpf,
                    EstadoCivil = estadoCivil,
                    DataNascimento = dataNascimento
                });
        }

        public async Task<EnderecoUsuario> ObterUltimoRegistro()
        {
            return await _connection.QueryFirstOrDefaultAsync<EnderecoUsuario>(Queries.Queries.ObterUltimoRegistro);
        }
    }
}
