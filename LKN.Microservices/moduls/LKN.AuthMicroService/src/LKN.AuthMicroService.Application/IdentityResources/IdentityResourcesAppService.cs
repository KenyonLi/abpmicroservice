using LKN.AuthMicroService.ApiResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.IdentityServer.IdentityResources;
using Volo.Abp.ObjectMapping;

namespace LKN.AuthMicroService.IdentityResources
{
    public class IdentityResourcesAppService : AuthMicroServiceAppService, IIdentityResourcesAppService
    {
        public IIdentityResourceRepository _identityResourceRepository;
        public IdentityResourcesAppService(IIdentityResourceRepository identityResourceRepository) {
            _identityResourceRepository = identityResourceRepository;
        }

        public async Task<IdentityResourceDto> CreateAsync(CreateIdentityResourceDto input)
        {
            // 1、创建Guid
            input.Id = GuidGenerator.Create();
            IdentityResource identityResource = ObjectMapper.Map<CreateIdentityResourceDto, IdentityResource>(input);

            // 3、创建identityResource申明实体
            foreach (var claim in input.Claims)
            {
                identityResource.AddUserClaim(claim);
            }

            identityResource = await _identityResourceRepository.InsertAsync(identityResource);

            // 5、映射IdentityResourceDto
            return ObjectMapper.Map<IdentityResource, IdentityResourceDto>(identityResource);
        }

        public Task<PagedResultDto<IdentityResourceDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResourceDto> UpdateAsync(Guid id, UpdateIdentityResourceDto input)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityResourceDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
