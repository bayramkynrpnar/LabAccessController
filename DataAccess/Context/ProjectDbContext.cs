using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Context
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
        {

        }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options, IConfiguration configuration)
         : base(options)
        {
            Configuration = configuration;
        }

        protected ProjectDbContext(DbContextOptions options, IConfiguration configuration)
         : base(options)
        {
            Configuration = configuration;
        }

        protected IConfiguration Configuration { get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                var connectionString = "Host=localhost;Port=5432;Database=labaccess;User Id=root;Password=root";
                optionsBuilder.UseNpgsql(connectionString);
          
        }
    }
}
