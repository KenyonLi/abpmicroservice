using AutoMapper;
using IdentityServer4.Models;
using LKN.AuthMicroService.ApiResources;

namespace LKN.AuthMicroService;

public class AuthMicroServiceApplicationAutoMapperProfile : Profile
{
    public AuthMicroServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<LKN.AuthMicroService.ApiResources.CreateApiResourceDto, Volo.Abp.IdentityServer.ApiResources.ApiResource>();
        CreateMap<Volo.Abp.IdentityServer.ApiResources.ApiResource, LKN.AuthMicroService.ApiResources.ApiResourceDto>();
        //CreateMap<CreateApiScopeDto, ApiScope>();
        //CreateMap<ApiScope, ApiScopeDto>();

        //CreateMap<Client, ClientDto>();
    }
}
