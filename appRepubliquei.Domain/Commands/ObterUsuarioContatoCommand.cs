using appRepubliquei.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Domain.Commands
{
    public class ObterUsuarioContatoCommand : IRequest<IEnumerable<vwUsuarioContato>> { }
}
