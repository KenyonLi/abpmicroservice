using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace LKN.AuthMicroService.IdentityResources
{
    public class CreateIdentityResourceDto: EntityDto<Guid>
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public bool Enabled { get; set; }

        public bool Required { get; set; }

        public bool Emphasize { get; set; }

        public bool ShowInDiscoveryDocument { get; set; }

        public string[] Claims { set; get; }
    }

    public class IdentityResourceClaim {
        public virtual string Type { get; protected set; }
    }
}