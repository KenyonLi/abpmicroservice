using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.IdentityServer.ApiResources;

namespace LKN.AuthMicroService.ApiResources
{
    [Dependency(ServiceLifetime.Singleton)]
    public class ApiResourceAppService : AuthMicroServiceAppService,IApiResourceAppService
    {
        public IApiResourceRepository _apiResourceRepository;
        public ApiResourceAppService(IApiResourceRepository apiResourceRepository)
        {
            this._apiResourceRepository = apiResourceRepository;
        }
        /// <summary>
        /// 创建apiResource API资源
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ApiResourceDto> CreateAsync(CreateApiResourceDto input)
        {
            // 1、创建Guid
            input.Id = GuidGenerator.Create();

            // 2、映射ApiResource
            ApiResource apiResource = ObjectMapper.Map<CreateApiResourceDto, ApiResource>(input);

            // 3、创建ApiResource申明实体
            foreach (var claim in input.claims)
            {
                apiResource.AddUserClaim(claim);
            }

            // 4、保存ApiResource
            apiResource = await _apiResourceRepository.InsertAsync(apiResource);


            // 5、映射ApiResourceDto
            return ObjectMapper.Map<ApiResource, ApiResourceDto>(apiResource);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResourceDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<ApiResourceDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResourceDto> UpdateAsync(Guid id, UpdateApiResourceDto input)
        {
            throw new NotImplementedException();
        }
    }
}
