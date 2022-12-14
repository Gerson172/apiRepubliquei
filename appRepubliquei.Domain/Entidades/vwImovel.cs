using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Entidades
{
    public class vwImovel
    {
        public int IdImovel { get; set; }
        public string Midia { get; set; }
        public string NomeImovel { get; set; }
        public int CapacidadePessoas { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public bool PossuiGaragem { get; set; }
        public bool PossuiAcessibilidade { get; set; }
        public bool PossuiPiscina { get; set; }
        public bool PossuiMobilia { get; set; }
        public int QuantidadeBanheiros { get; set; }
        public int QuantidadeQuartos { get; set; }
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        //public int Celular { get; set; }
        //public int Telefone { get; set; }
        //public string Email { get; set; }
        public int CEP { get; set; }
        public string Localidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public string Uf { get; set; }
        public bool Fumante { get; set; }
        public bool Animal { get; set; }
        public bool Alcool { get; set; }
        public bool Visitas { get; set; }
        public bool Crianca { get; set; }
        public bool Drogas { get; set; }
        public string TipoImovel { get; set; }
        public string TipoSexo { get; set; }
        public string TipoQuarto { get; set; }
    }
}
