using appRepubliquei.Domain.Commands;
using appRepubliquei.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Contracts.Services
{
    public interface IImovelService
    {
        Task<RetornoSimples> CadastrarImovel(InserirImovelCommand request);
        Task<IEnumerable<vwImovel>> ObterImovel();
        Task<vwImovel> ObterImovelPorId(string idImovel);
        Task<RetornoSimples> DeletarImovelPorId(int idImovel);
    }
}
