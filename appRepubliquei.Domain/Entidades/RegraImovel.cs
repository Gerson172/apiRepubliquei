using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Entidades
{
    public class RegraImovel
    {
        [JsonIgnore]
        public int ID { get; set; }
        public bool Fumante { get; set; }
        public bool Animal { get; set; }
        public bool Alcool { get; set; }
        public bool Visitas { get; set; }
        public bool Crianca { get; set; }
        public bool Drogas { get; set; }

    }
}
