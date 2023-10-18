using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LKN.AuthMicroService.MongoDB;

[ConnectionStringName(AuthMicroServiceDbProperties.ConnectionStringName)]
public interface IAuthMicroServiceMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
