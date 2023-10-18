using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.IdentityServer.ApiScopes;
using LKN.AuthMicroService.ApiResources;
using LKN.AuthMicroService.ApiScopes;

namespace LKN.AuthMicroService.ApiScopes
{

    [Dependency(ServiceLifetime.Singleton)]
    public class ApiScopeAppService : AuthMicroServiceAppService, IApiScopeAppService
    {
        public IApiScopeRepository _ApiScopeRepository;
        public ApiScopeAppService(IApiScopeRepository ApiScopeRepository)
        {
            this._ApiScopeRepository = ApiScopeRepository;
        }

        public async Task<ApiScopeDto> CreateAsync(CreateApiScopeDto input)
        {
            // 1、创建Guid
            input.Id = GuidGenerator.Create();

            // 2、映射ApiScope
            ApiScope ApiScope = ObjectMapper.Map<CreateApiScopeDto, ApiScope>(input);

            // 3、保存ApiScope
            ApiScope = await _ApiScopeRepository.InsertAsync(ApiScope);

            return ObjectMapper.Map<ApiScope, ApiScopeDto>(ApiScope);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ApiScopeDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<ApiScopeDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ApiScopeDto> UpdateAsync(Guid id, UpdateApiScopeDto input)
        {
            throw new NotImplementedException();
        }
    }
}
