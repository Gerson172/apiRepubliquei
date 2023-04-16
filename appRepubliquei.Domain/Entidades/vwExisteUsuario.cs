using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Entidades
{
    public class vwExisteUsuario
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public bool Autheiticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AcessToken { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public ExisteUsuarioInternal ExisteUsuario { get; set; }
    }
    public class ExisteUsuarioInternal
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
    }
}
