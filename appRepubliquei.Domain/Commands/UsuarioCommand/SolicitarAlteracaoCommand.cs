using appRepubliquei.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Commands.UsuarioCommand
{
    public class SolicitarAlteracaoCommand : IRequest<RetornoSimples>
    {
        public string Email { get; set; }
    }
}
