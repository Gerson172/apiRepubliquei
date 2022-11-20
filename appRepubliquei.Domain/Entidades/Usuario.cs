using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public string EstadoCivil { get; set; }
        public string Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool CheckProprietario { get; set; }
        public int? IdEnderecoUsuario { get; set; }
        public int? IdContato { get; set; }
        public int? IdCaracteristicaUsuario { get; set; }
    }
}
