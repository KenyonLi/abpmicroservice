using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LKN.User.EntityFrameworkCore;

public class UserHttpApiHostMigrationsDbContext : AbpDbContext<UserHttpApiHostMigrationsDbContext>
{
    public UserHttpApiHostMigrationsDbContext(DbContextOptions<UserHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureUser();
    }
}
