using appRepubliquei.Domain.Contracts.Repository;
using appRepubliquei.Domain.Entidades;
using appRepubliquei.Infra.Data.Contexts;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
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

        public async Task<IEnumerable<Usuario>> ObterUsuario()
        {
            return await _connection.QueryAsync<Usuario>(Queries.Queries.ObterUsuario);
        }

        public async Task<IEnumerable<vwUsuarioContato>> ObterUsuarioContato()
        {
            return await _connection.QueryAsync<vwUsuarioContato>(Queries.Queries.ObterUsuarioContato);
        }

        public async Task<vwUsuarioContato> ObterUsuarioContatoPorId(int idUsuario)
        {
            return await _connection.QueryFirstOrDefaultAsync<vwUsuarioContato>(Queries.Queries.ObterUsuarioContatoPorId,
                new
                {
                    IdUsuario = idUsuario
                });
        }

        public async Task InserirEnderecoUsuario(int cep, string estado, string cidade, string bairro, string logradouro, string numero, string complemento)
        {
            await _connection.ExecuteAsync(Queries.Queries.InserirEnderecoUsuario,
                new
                {
                    Cep = cep,
                    Estado = estado,
                    Cidade = cidade,
                    Bairro = bairro,
                    Logradouro = logradouro,
                    Numero = numero,
                    Complemento = complemento
                });
        }

        public async Task InserirContatoUsuario(string email, string celular, string telefone)
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

        public async Task InserirUsuario(string nome, string sobrenome, string senha, string cpf, string estadoCivil, DateTime dataNascimento, bool checkProprietario, int fkEnderecoUsuario, int fkContato, int fkCaracteristicaUsuario)
        {
            await _connection.ExecuteAsync(Queries.Queries.InserirUsuario,
                new
                {
                    Nome = nome,
                    Sobrenome = sobrenome,
                    Senha = senha,
                    Cpf = cpf,
                    EstadoCivil = estadoCivil,
                    DataNascimento = dataNascimento,
                    CheckProprietario = checkProprietario,
                    IdEnderecoUsuario = fkEnderecoUsuario,
                    IdContato = fkContato,
                    IdCaracteristicaUsuario = fkCaracteristicaUsuario,
                });
        }

        public async Task<EnderecoUsuario> ObterUltimoRegistroInseridoUsuario()
        {
            return await _connection.QueryFirstOrDefaultAsync<EnderecoUsuario>(Queries.Queries.ObterUltimoRegistroInseridoUsuario);
        }

        public async Task<Contato> ObterUltimoRegistroInseridoContatoUsuario()
        {
            return await _connection.QueryFirstOrDefaultAsync<Contato>(Queries.Queries.ObterUltimoRegistroInseridoContatoUsuario);
        }

        public async Task<CaracteristicaUsuario> ObterUltimoRegistroInseridoCaracteristicaUsuario()
        {
            return await _connection.QueryFirstOrDefaultAsync<CaracteristicaUsuario>(Queries.Queries.ObterUltimoRegistroInseridoCaracteristicaUsuario);
        }

        public bool CheckEmailESenha(string email, string cpf)
        {
            return _connection.QuerySingleOrDefault<bool>(Queries.Queries.VerificarExisteEmailSenha,
                new
                {
                    Email = email,
                    Cpf = cpf
                });
        }
    }
}
