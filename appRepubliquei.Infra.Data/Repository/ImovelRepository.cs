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
    public class ImovelRepository : IImovelRepository
    {
        private readonly SqlConnection _connection;
        public ImovelRepository(IDatabaseContext context)
        {
            _connection = context.SqlConnection;
        }


        public async Task InserirCaracteristicaImovel(string tipoImovel, string tipoQuarto, string tipoSexo)
        {
            await _connection.ExecuteAsync(Queries.Queries.InserirCaracteristicaImovel,
                new
                {
                    TipoImovel = tipoImovel,
                    TipoQuarto = tipoQuarto,
                    TipoSexo = tipoSexo,
                });
        }

        public async Task InserirEnderecoImovel(int cep, string cidade, string bairro, string logradouro, string numero, string complemento, string estado)
        {
            await _connection.ExecuteAsync(Queries.Queries.InserirEnderecoImovel,
                new
                {
                    Cep = cep,
                    Cidade = cidade,
                    Bairro = bairro,
                    Logradouro = logradouro,
                    Numero = numero,
                    Complemento = complemento,
                    Estado = estado,
                });
        }

        public async Task InserirRegraImovel(bool fumante, bool animal, bool alcool, bool visitas, bool crianca, bool drogas)
        {
            await _connection.ExecuteAsync(Queries.Queries.InserirRegraImovel,
                new
                {
                    Fumante = fumante,
                    Animal = animal,
                    Alcool = alcool,
                    Visitas = visitas,
                    Crianca = crianca,
                    Drogas = drogas,
                });
        }
        public async Task InserirImovel(string midia, int capacidadePessoas, decimal valor, string descricao,
            bool possuiAcessibilidade, bool possuiGaragem, bool possuiAcademia, bool possuiMobilia, bool possuiAreaLazer,
            bool possuiPiscina, int quantidadeBanheiros, int quantidadeComodo, int quantidadeQuartos, int caracteristicaImovel, int enderecoImovel, int regraImovel, int idUsuario, string nomeImovel)
        {
            await _connection.ExecuteAsync(Queries.Queries.InserirImovel,
                new
                {
                     Midia = midia,
                     CapacidadePessoas = capacidadePessoas,
                     Valor = valor,
                     Descricao = descricao,
                     PossuiAcessibilidade = possuiAcessibilidade,
                     PossuiGaragem = possuiGaragem,
                     PossuiAcademia = possuiAcademia,
                     PossuiMobilia = possuiMobilia,
                     PossuiAreaLazer = possuiAreaLazer,
                     PossuiPiscina = possuiPiscina,
                     QuantidadeBanheiros = quantidadeBanheiros,
                     QuantidadeComodo = quantidadeComodo,
                     QuantidadeQuartos = quantidadeQuartos,
                     CaracteristicaImovel = caracteristicaImovel,
                     EnderecoImovel = enderecoImovel,
                     RegraImovel = regraImovel,
                     IdUsuarioProprietario = idUsuario,
                     NomeImovel = nomeImovel
                });
        }

        public async Task<CaracteristicaImovel> ObterUltimoRegistroCaracteristicaImovel()
        {
            return await _connection.QueryFirstOrDefaultAsync<CaracteristicaImovel>(Queries.Queries.ObterUltimoRegistroInseridoCaracteristicaImovel);
        }

        public async  Task<EnderecoImovel> ObterUltimoRegistroEnderecoImovel()
        {
            return await _connection.QueryFirstOrDefaultAsync<EnderecoImovel>(Queries.Queries.ObterUltimoRegistroInseridoEnderecoImovel);
        }

        public async  Task<RegraImovel> ObterUltimoRegistroRegraImovel()
        {
            return await _connection.QueryFirstOrDefaultAsync<RegraImovel>(Queries.Queries.ObterUltimoRegistroInseridoRegraImovel);
        }

        public async Task<IEnumerable<Imovel>> ObterImovel()
        {
            return await _connection.QueryAsync<Imovel>(Queries.Queries.ObterImovel);

        }

        public async Task<Imovel> ObterImovelPorId(string idImovel)
        {
            return await _connection.QueryFirstOrDefaultAsync<Imovel>(Queries.Queries.ObterImovelPorId, new
            {
                IdImovel = idImovel
            });

        }
    }
}
