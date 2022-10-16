using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain
{
    public class Retorno<TValor>
    {
        public string Mensagem { get; private set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public TValor Valor { get; private set; }   
        public Retorno(string mensagem, TValor valor)
        {
            Valor = valor;
            Mensagem = mensagem;
        }
    }
}
