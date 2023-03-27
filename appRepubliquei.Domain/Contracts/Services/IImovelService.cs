using appRepubliquei.Domain.Commands.ImovelCommand;
using appRepubliquei.Domain.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Contracts.Services
{
    public interface IImovelService
    {
        Task<RetornoSimples> CadastrarImovel(InserirImovelCommand request);
        Task<IEnumerable<vwImovel>> ObterImovel();
        Task<vwImovel> ObterImovelPorId(string idImovel);
        Task<RetornoSimples> DeletarImovelPorId(int idImovel);
        Task<RetornoSimples> AtualizarImovel(int idImovel);
    }
}
