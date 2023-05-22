using appRepubliquei.Domain.Entidades;
using MediatR;
using System.Collections.Generic;

namespace appRepubliquei.Domain.Commands.UsuarioCommand
{
    public class ExcluirUsuarioPorIdCommand : IRequest<RetornoSimples> 
    {
        public int IdUsuario { get; set; }
    }
}
