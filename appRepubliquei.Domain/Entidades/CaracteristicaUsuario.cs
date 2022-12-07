using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Entidades
{
    public class CaracteristicaUsuario
    {
        [JsonIgnore]
        public int ID { get; set; }
        public string Religiao { get; set; }
        public string Genero { get; set; }
        public string Sexo { get; set; }
        public string OrientacaoSexual { get; set; }
        public string AreaInteresse { get; set; }
    }
}
