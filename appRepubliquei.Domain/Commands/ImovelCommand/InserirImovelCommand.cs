using appRepubliquei.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Commands.ImovelCommand
{
    public class InserirImovelCommand : IRequest<RetornoSimples>
    {
        public string Midia { get; set; }
        public int QuantidadeComodo { get; set; }
        public int CapacidadePessoas { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public bool PossuiAcessibilidade { get; set; }
        public bool PossuiGaragem { get; set; }
        public bool PossuiAcademia { get; set; }
        public bool PossuiMobilia { get; set; }
        public bool PossuiAreaLazer { get; set; }
        public bool PossuiPiscina { get; set; }
        public int QuantidadeBanheiros { get; set; }
        public int QuantidadeQuartos { get; set; }
        public string NomeImovel { get; set; }
        public RegraImovel RegraImovel { get; set; }
        public CaracteristicaImovel CaracteristicaImovel { get; set; }
        public EnderecoImovel EnderecoImovel { get; set; }
        public int IdUsuario { get; set; }

    }
}
