﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace LKN.AuthMicroService.ApiResources
{
    public class CreateApiScopeDto : EntityDto<Guid>
    {

        public string Name { get; set; }

        public string DisplayName { get; set; }
       
    }
}
