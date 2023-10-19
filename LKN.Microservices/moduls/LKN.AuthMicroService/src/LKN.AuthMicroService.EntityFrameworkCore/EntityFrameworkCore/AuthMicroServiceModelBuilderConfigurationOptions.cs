using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LKN.AuthMicroService.EntityFrameworkCore;

public class AuthMicroServiceModelBuilderConfigurationOptions: AbpModelBuilderConfigurationOptions
{
    public AuthMicroServiceModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
    {

    }
}