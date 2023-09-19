using JetBrains.Annotations;
using System.Diagnostics.CodeAnalysis;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LKN.Order.EntityFrameworkCore
{
    public class OrderModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public OrderModelBuilderConfigurationOptions(
            [JetBrains.Annotations.NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}
