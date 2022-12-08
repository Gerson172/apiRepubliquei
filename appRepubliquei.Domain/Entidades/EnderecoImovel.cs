using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Entidades
{
    public class EnderecoImovel
    {
        [JsonIgnore]
        public int ID { get; set; }
        public int CEP { get; set; }
        public string Localidade { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Uf { get; set; }

    }
}
