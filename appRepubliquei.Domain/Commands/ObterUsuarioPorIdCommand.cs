using appRepubliquei.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Commands
{
    public class ObterUsuarioPorIdCommand : IRequest<Usuario>
    {
        public int IdUsuario { get; set; }
    }
}
