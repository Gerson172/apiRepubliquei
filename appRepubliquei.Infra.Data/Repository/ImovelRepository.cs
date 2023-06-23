using appRepubliquei.Domain.Commands.ImovelCommand;
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
        public async Task InserirImovel(int capacidadePessoas, decimal valor, string descricao,
                                        bool possuiAcessibilidade, bool possuiGaragem, bool possuiAcademia, 
                                        bool possuiMobilia, bool possuiAreaLazer,bool possuiPiscina,
                                        int quantidadeBanheiros, int quantidadeQuartos,
                                        int caracteristicaImovel, int enderecoImovel, int regraImovel,
                                        int? idUsuario, string nomeImovel,bool verificado, string universidadeProxima, 
                                        string midia1, string midia2, string midia3)
        {
            await _connection.ExecuteAsync(Queries.Queries.InserirImovel,
                new
                {
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
                     QuantidadeQuartos = quantidadeQuartos,
                     CaracteristicaImovel = caracteristicaImovel,
                     EnderecoImovel = enderecoImovel,
                     RegraImovel = regraImovel,
                     IdUsuarioProprietario = idUsuario,
                     NomeImovel = nomeImovel,
                     Verificado = verificado,
                     UniversidadeProxima = universidadeProxima,
                     Midia1 = midia1,
                     Midia2 = midia2,
                     Midia3 = midia3
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

        public async Task<IEnumerable<vwImovel>> ObterImovel()
        {
            return await _connection.QueryAsync<vwImovel>(Queries.Queries.ObterImovel);

        }

        public async Task<vwImovel> ObterImovelPorId(int idImovel)
        {
            return await _connection.QueryFirstOrDefaultAsync<vwImovel>(Queries.Queries.ObterImovelPorId, new
            {
                IdImovel = idImovel
            });

        }
        public async Task DeletarImovelPorId(int idImovel)
        {
            await _connection.ExecuteAsync(Queries.Queries.DeletarImovelPorId, new
            {
                IdImovel = idImovel
            });
        }

        public async Task<IEnumerable<vwImovel>> ObterImovelPorUsuarioId(int? idUsuario)
        {
            return await _connection.QueryAsync<vwImovel>(Queries.Queries.ObterImovelPorUsuarioId, new
            {
                IdUsuario = idUsuario
            });
        }

        public async Task AtualizarImovel(AtualizarImovelCommand request, int IdEnderecoImovel, int IdCaracteristicaImovel, int IdImovel, int IdRegraImovel)
        {
            await _connection.ExecuteAsync(Queries.Queries.AtualizarImovel,
                new
                {
                     Midia = request.Midia,
                     NomeImovel = request.NomeImovel,
                     CapacidadePessoas = request.CapacidadePessoas,
                     Valor = request.Valor,
                     Descricao = request.Descricao,
                     PossuiGaragem = request.PossuiGaragem,
                     PossuiAcessibilidade = request.PossuiAcessibilidade,
                     PossuiPiscina = request.PossuiPiscina,
                     PossuiMobilia = request.PossuiMobilia,
                     QuantidadeBanheiros = request.QuantidadeBanheiros,
                     QuantidadeQuartos = request.QuantidadeQuartos,
                     UniversidadeProxima = request.UniversidadeProxima,
                     IdImovel = IdImovel,
                     Fumante = request.Fumante,
                     Animal = request.Animal,
                     Alcool = request.Alcool,
                     Visitas = request.Visitas,
                     Crianca = request.Crianca,
                     Drogas = request.Drogas,
                     IdRegraImovel = IdRegraImovel,
                     TipoImovel = request.TipoImovel,
                     TipoQuarto = request.TipoQuarto,
                     TipoSexo = request.TipoSexo,
                     IdCaracteristicaImovel = IdCaracteristicaImovel,
                     CEP = request.CEP,
                     Cidade = request.Cidade,
                     Bairro = request.Bairro,
                     Logradouro = request.Logradouro,
                     Numero = request.Numero,
                     Complemento  = request.Complemento,
                     Estado = request.Estado,
                     IdEnderecoImovel = IdEnderecoImovel
                });
        }
    }
}
