using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.IdentityServer.IdentityResources;

namespace LKN.AuthMicroService.IdentityResources
{
    public interface IIdentityResourcesAppService:ICrudAppService<
                                            IdentityResourceDto,
                                            Guid,
                                            PagedAndSortedResultRequestDto,
                                            CreateIdentityResourceDto,
                                            UpdateIdentityResourceDto>
    {

    }
}
