using appRepubliquei.Domain.Contracts.Repository;
using appRepubliquei.Domain.Entidades;
using appRepubliquei.Infra.Data.Contexts;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Infra.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlConnection _connection;
        public UsuarioRepository(IDatabaseContext context)
        {
            _connection = context.SqlConnection;
        }

        public async Task<Usuario> ObterUsuarioPorId(int idUsuario)
        {
            return await _connection.QueryFirstOrDefaultAsync<Usuario>(Queries.Queries.ObterUsuarioPorId,
                new
                {
                    idUsuario = idUsuario
                });
        }
    }
}
