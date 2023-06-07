using appRepubliquei.Domain.Commands.ImovelCommand;
using appRepubliquei.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Contracts.Repository
{
    public interface IImovelRepository
    {
        Task InserirCaracteristicaImovel(string tipoImovel, string tipoQuarto, string tipoSexo);
        Task InserirEnderecoImovel(int cep, string cidade, string bairro, string logradouro, string numero, string complemento, string estado);
        Task InserirRegraImovel(bool fumante, bool animal, bool alcool, bool visitas, bool crianca, bool drogas);
        Task<CaracteristicaImovel> ObterUltimoRegistroCaracteristicaImovel();
        Task<EnderecoImovel> ObterUltimoRegistroEnderecoImovel();
        Task<RegraImovel> ObterUltimoRegistroRegraImovel();
        Task InserirImovel(string midia, int capacidadePessoas, decimal valor, string descricao, bool possuiAcessibilidade, 
            bool possuiGaragem, bool possuiAcademia, bool possuiMobilia, bool possuiAreaLazer, bool possuiPiscina, 
            int quantidadeBanheiros, int quantidadeQuartos, 
            int caracteristicaImovel, int enderecoImovel, int regraImovel, int? idUsuario, string nomeImovel, 
            bool verificado, string universidadeProxima);
        Task<IEnumerable<vwImovel>> ObterImovel();
        Task<vwImovel> ObterImovelPorId(int idImovel);
        Task DeletarImovelPorId(int idImovel);
        Task<IEnumerable<vwImovel>> ObterImovelPorUsuarioId(int? idUsuario);
        Task AtualizarImovel(AtualizarImovelCommand request,int IdEnderecoImovel, int IdCaracteristicaImovel, int IdImovel, int IdRegraImovel);
    }
}
