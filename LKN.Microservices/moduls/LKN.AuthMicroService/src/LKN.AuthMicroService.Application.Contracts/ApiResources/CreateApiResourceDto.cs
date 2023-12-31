﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace LKN.AuthMicroService.ApiResources
{
    public class CreateApiResourceDto : EntityDto<Guid>
    {
        public virtual string Name { get; set; }

        public virtual string DisplayName { get; set; }

        public virtual string Description { get; set; }

        public string[] claims { set; get; }
    }


    public class ApiResourceClaim
    {
        public virtual string Type { get; protected set; }
    }
    public class IdentityResourceProperty { 
       public virtual string Type { get; protected set; }

    }
}
