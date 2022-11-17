using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Jantuscara.Repository
{
    internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MySqlDbContext>
    {
        public MySqlDbContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var filename = Directory.GetCurrentDirectory() + $"/../Jantuscara.API/appsettings.{environmentName}.json";

            var configuration = new ConfigurationBuilder().AddJsonFile(filename).Build();
            var connectionString = "Server=localhost;Database=jantuscaradb;Uid=root;Pwd=root;";

            var builder = new DbContextOptionsBuilder<MySqlDbContext>();
            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new MySqlDbContext(builder.Options);
        }
    }
}
