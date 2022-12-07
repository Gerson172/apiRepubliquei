using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Entidades
{
    public class CaracteristicaImovel
    {
        [JsonIgnore]
        public int ID { get; set; }

        public string TipoImovel { get; set; }

        public string TipoQuarto { get; set; }

        public string TipoSexo { get; set; }

    }
}
