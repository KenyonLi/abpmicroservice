﻿using System;
using Volo.Abp.Application.Dtos;

namespace LKN.AuthMicroService.ApiResources
{
    public class UpdateApiResourceDto : EntityDto<Guid>
    {
        public virtual string Name { get; protected set; }

        public virtual string DisplayName { get; set; }

        public virtual string Description { get; set; }

        public ApiResourceClaim[] apiResourceClaims { set; get; }
    }
}
