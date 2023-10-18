using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace LKN.AuthMicroService.EntityFrameworkCore;

[ConnectionStringName(AuthMicroServiceDbProperties.ConnectionStringName)]
public class AuthMicroServiceDbContext : AbpDbContext<AuthMicroServiceDbContext>, IAuthMicroServiceDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public AuthMicroServiceDbContext(DbContextOptions<AuthMicroServiceDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAuthMicroService();
    }
}
