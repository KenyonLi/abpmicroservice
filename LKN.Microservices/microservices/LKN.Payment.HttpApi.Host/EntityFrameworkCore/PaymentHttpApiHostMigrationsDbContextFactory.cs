using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LKN.Payment.EntityFrameworkCore;

public class PaymentHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<PaymentHttpApiHostMigrationsDbContext>
{
    public PaymentHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<PaymentHttpApiHostMigrationsDbContext>()
            //.UseSqlServer(configuration.GetConnectionString("Payment"));
            .UseMySql(configuration.GetConnectionString("Payment"), MySqlServerVersion.LatestSupportedServerVersion);
        return new PaymentHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
