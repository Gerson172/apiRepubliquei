using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace appRepubliquei.Infra.Data.Contexts
{
    public interface IDatabaseContext : IDisposable
    {
        SqlConnection SqlConnection { get; }
        DbContext Db { get; }
    }
}
