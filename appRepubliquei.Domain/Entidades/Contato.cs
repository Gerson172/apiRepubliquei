using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Entidades
{
    public class Contato
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public int? Telefone { get; set; }
        public int Celular { get; set; }

    }
}
