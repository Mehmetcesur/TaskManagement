using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.Helpers
{
    public static class DatabaseProviderHelper
    {
        public static void ConfigureDatabaseProvider(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            var databaseProvider = configuration["DatabaseProvider"];

            if (databaseProvider == "PostgreSQL")
            {
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgreSQL"));
            }
            else if (databaseProvider == "SQLServer")
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQLServer"));
            }
            else
            {
                throw new Exception("Unsupported database provider specified in the configuration.");
            }
        }
    }
}
