using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace LKN.AuthMicroService.ApiResources
{
    public class ApiResourceDto : EntityDto<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual string DisplayName { get; set; }

        public virtual string Description { get; set; }

        public virtual bool Enabled { get; set; }

        public virtual string AllowedAccessTokenSigningAlgorithms { get; set; }

        public virtual bool ShowInDiscoveryDocument { get; set; } = true;
    }
}
