using appRepubliquei.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Commands.UsuarioCommand
{
    public class AtualizarUsuarioCommand : IRequest<RetornoSimples>
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string CPF { get; set; }
        public string EstadoCivil { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
