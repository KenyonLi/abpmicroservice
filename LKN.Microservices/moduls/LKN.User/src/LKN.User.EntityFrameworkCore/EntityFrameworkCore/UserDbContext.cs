using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace LKN.User.EntityFrameworkCore;

[ConnectionStringName(UserDbProperties.ConnectionStringName)]
public class UserDbContext : AbpDbContext<UserDbContext>, IUserDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public UserDbContext(DbContextOptions<UserDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureUser();
    }
}
