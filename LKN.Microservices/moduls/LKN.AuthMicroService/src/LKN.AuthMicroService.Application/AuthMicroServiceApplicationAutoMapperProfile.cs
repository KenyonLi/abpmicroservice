using AutoMapper;
using IdentityServer4.Models;
using LKN.AuthMicroService.ApiResources;
using LKN.AuthMicroService.ApiScopes;

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
        
        CreateMap<LKN.AuthMicroService.ApiScopes.CreateApiScopeDto, Volo.Abp.IdentityServer.ApiScopes.ApiScope>();
        CreateMap<Volo.Abp.IdentityServer.ApiScopes.ApiScope, LKN.AuthMicroService.ApiScopes.CreateApiScopeDto>();
        CreateMap<Volo.Abp.IdentityServer.ApiScopes.ApiScope, LKN.AuthMicroService.ApiScopes.ApiScopeDto>();
       
        CreateMap<Volo.Abp.IdentityServer.Clients.Client, LKN.AuthMicroService.Clients.ClientDto>();

        CreateMap<LKN.AuthMicroService.IdentityResources.CreateIdentityResourceDto, Volo.Abp.IdentityServer.IdentityResources.IdentityResource>();
        CreateMap<Volo.Abp.IdentityServer.IdentityResources.IdentityResource, LKN.AuthMicroService.IdentityResources.IdentityResourceDto>();

    }
}
