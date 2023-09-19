using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LKN.Product.EntityFrameworkCore
{
    public class ProductModelBuilderConfigurationOptions: AbpModelBuilderConfigurationOptions
    {
        public ProductModelBuilderConfigurationOptions(
            [JetBrains.Annotations.NotNull] string tablePrefix = "",
            [CanBeNull] string schema = ""):base(tablePrefix,schema) {
        }
    }
}
