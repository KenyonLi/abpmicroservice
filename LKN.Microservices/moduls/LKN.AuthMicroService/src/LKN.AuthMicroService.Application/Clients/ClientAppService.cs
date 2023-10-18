using IdentityServer4.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.IdentityServer.Clients;
using LKN.AuthMicroService.ApiResources;
using Client = Volo.Abp.IdentityServer.Clients.Client;

namespace LKN.AuthMicroService.Clients
{

    [Dependency(ServiceLifetime.Singleton)]
    public class ClientAppService : AuthMicroServiceAppService, IClientAppService
    {
        public IClientRepository _ClientRepository;
        public ClientAppService(IClientRepository ClientRepository)
        {
            this._ClientRepository = ClientRepository;
        }

        public async Task<ClientDto> CreateAsync(CreateClientDto input)
        {
            var  client = await _ClientRepository.InsertAsync(
                    new Client(
                        GuidGenerator.Create(),
                        input.ClientName
                    )
                    {
                        ClientName = input.ClientName,
                        ProtocolType = "oidc",
                        Description = input.ClientName,
                        AlwaysIncludeUserClaimsInIdToken = true,
                        AllowOfflineAccess = true,
                        AbsoluteRefreshTokenLifetime = 31536000, //365 days
                        AccessTokenLifetime = 31536000, //365 days
                        AuthorizationCodeLifetime = 300,
                        IdentityTokenLifetime = 300,
                        RequireConsent = false,
                        RequirePkce = false
                    },
                    autoSave: true
            );

            foreach (var scope in input.Scopes)
            {
                if (client.FindScope(scope) == null)
                {
                    client.AddScope(scope);
                }
            }

            foreach (var grantType in input.GrantTypes)
            {
                if (client.FindGrantType(grantType) == null)
                {
                    client.AddGrantType(grantType);
                }
            }

            if (client.FindSecret(input.Secret) == null)
            {
                client.AddSecret(input.Secret.Sha256());
            }

            if (input.RedirectUri != null)
            {
                if (client.FindRedirectUri(input.RedirectUri) == null)
                {
                    client.AddRedirectUri(input.RedirectUri);
                }
            }

            if (input.PostLogoutRedirectUri != null)
            {
                if (client.FindPostLogoutRedirectUri(input.PostLogoutRedirectUri) == null)
                {
                    client.AddPostLogoutRedirectUri(input.PostLogoutRedirectUri);
                }
            }

            client = await _ClientRepository.UpdateAsync(client);
            return ObjectMapper.Map<Client, ClientDto>(client);
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ClientDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResultDto<ClientDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        public Task<ClientDto> UpdateAsync(Guid id, UpdateClientDto input)
        {
            throw new NotImplementedException();
        }
    }
}
