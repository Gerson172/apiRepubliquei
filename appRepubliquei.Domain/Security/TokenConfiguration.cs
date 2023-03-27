using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Security
{
    public class TokenConfigurations
    {
        public string Audience { get; set; } // publico
        public string Issuer { get; set; } // emissor
        public int Seconds { get; set; } // duracao token
    }
}
