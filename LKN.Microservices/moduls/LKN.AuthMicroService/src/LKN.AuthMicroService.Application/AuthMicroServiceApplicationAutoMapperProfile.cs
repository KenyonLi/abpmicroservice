using AutoMapper;
using IdentityServer4.Models;
using LKN.AuthMicroService.ApiResources;
using Volo.Abp.IdentityServer.Clients;

namespace LKN.AuthMicroService;

public class AuthMicroServiceApplicationAutoMapperProfile : Profile
{
    public AuthMicroServiceApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<CreateApiResourceDto, ApiResource>();
        CreateMap<ApiResource, ApiResourceDto>();

       // CreateMap<CreateApiScopeDto, ApiScope>();
        //CreateMap<ApiScope, ApiScopeDto>();

        //CreateMap<Client, ClientDto>();
    }
}
