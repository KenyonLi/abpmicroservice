using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LKN.Order.EntityFrameworkCore;

public class OrderHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<OrderHttpApiHostMigrationsDbContext>
{
    public OrderHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<OrderHttpApiHostMigrationsDbContext>()
            .UseMySql(configuration.GetConnectionString("Order"),MySqlServerVersion.LatestSupportedServerVersion);

        return new OrderHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
