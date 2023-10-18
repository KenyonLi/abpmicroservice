using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LKN.AuthMicroService.EntityFrameworkCore
{
    public class AuthMicroServiceModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
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
}
