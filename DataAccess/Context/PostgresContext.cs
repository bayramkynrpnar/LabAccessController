using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Context
{
    public class PostgresContext : ProjectDbContext
    {
        public PostgresContext()
        {

        }

        public PostgresContext(DbContextOptions<PostgresContext> options, IConfiguration configuration)
            : base(options, configuration)
        {
        }
    }
}
