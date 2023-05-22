using appRepubliquei.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Commands.UsuarioCommand
{
    public class CadastrarUsuarioCommand : IRequest<RetornoSimples>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool CheckProprietario { get; set; }
        public bool CheckTermos { get; set; }
        public Contato Contato { get; set; }
        public EnderecoUsuario EnderecoUsuario { get; set; }
        public CaracteristicaUsuario CaracteristicaUsuario { get; set; }
    }
}
