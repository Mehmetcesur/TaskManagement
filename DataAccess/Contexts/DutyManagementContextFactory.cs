using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DataAccess.Contexts
{
    public class DutyManagementContextFactory : IDesignTimeDbContextFactory<DutyManagementContext>
    {
        public DutyManagementContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<DutyManagementContext>();

            var databaseProvider = configuration["DatabaseProvider"];
            if (databaseProvider == "PostgreSQL")
            {
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
            }
            else
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQLServer"));
            }

            return new DutyManagementContext(optionsBuilder.Options, configuration);
        }
    }
}
