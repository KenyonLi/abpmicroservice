using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LKN.AuthMicroService.ApiResources
{
    public interface IApiResourceAppService:ICrudAppService<ApiResourceDto,
                                            Guid,
                                            PagedAndSortedResultRequestDto,
                                            CreateApiResourceDto,
                                            UpdateApiResourceDto>
    {
    }
}
