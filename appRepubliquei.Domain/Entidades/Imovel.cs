using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Entidades
{
    public class Imovel
    {
        public int ID { get; set; }
        public string Midia { get; set; }
        public int QuantidadeComodo { get; set; }
        public int CapacidadePessoas { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public bool PossuiGaragem { get; set; }
        public bool PossuiAcessibilidade { get; set; }
        public int? IdRegraImovel { get; set; }
        public int? IdCaracteristicaImovel { get; set; }
        public int? IdEnderecoImovel { get; set; }
        public int? IdUsuario { get; set; }

    }
}
