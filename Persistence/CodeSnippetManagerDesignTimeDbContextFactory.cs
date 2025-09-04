using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class CodeSnippetManagerDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CodeSnipperManagerDbContext>
    {
        public CodeSnipperManagerDbContext CreateDbContext(string[] args)
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../WebUI");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: true)
                .Build();


            var conn = configuration.GetConnectionString("CodeSnippetManagerMainDbConnectionString");

            var optionsBuilder = new DbContextOptionsBuilder<CodeSnipperManagerDbContext>();


            optionsBuilder.UseNpgsql(conn);

            return new CodeSnipperManagerDbContext(optionsBuilder.Options);
        }
    }
}
