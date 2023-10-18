using Volo.Abp;
using Volo.Abp.MongoDB;

namespace LKN.AuthMicroService.MongoDB;

public static class AuthMicroServiceMongoDbContextExtensions
{
    public static void ConfigureAuthMicroService(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
