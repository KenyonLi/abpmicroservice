using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace LKN.AuthMicroService.EntityFrameworkCore;

[ConnectionStringName(AuthMicroServiceDbProperties.ConnectionStringName)]
public interface IAuthMicroServiceDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
