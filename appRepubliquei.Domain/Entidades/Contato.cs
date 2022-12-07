using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Entidades
{
    public class Contato
    {
        [JsonIgnore]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }

    }
}
