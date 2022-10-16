using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Infra.Data.Queries
{
    internal static class Queries
    {
        public const string ObterUsuarioPorId = @"SELECT * FROM Usuario WHERE ID = @idUsuario";
    }
}
