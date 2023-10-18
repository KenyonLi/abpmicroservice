using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LKN.AuthMicroService.EntityFrameworkCore;

public class AuthMicroServiceHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<AuthMicroServiceHttpApiHostMigrationsDbContext>
{
    public AuthMicroServiceHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<AuthMicroServiceHttpApiHostMigrationsDbContext>()
            //.UseSqlServer(configuration.GetConnectionString("AuthMicroService"));
            .UseMySql(configuration.GetConnectionString("AuthMicroService"),MySqlServerVersion.LatestSupportedServerVersion);
        return new AuthMicroServiceHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
