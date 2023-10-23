using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Http.Client.Authentication;
using Volo.Abp.IdentityModel;

namespace LKN.Microservices.ClientHttps.Https
{
    /// <summary>
    /// 动态C#客户端设置请求头
    /// </summary>
    [Dependency(ServiceLifetime.Singleton)]
    public class RemoteServiceHttpClientAuthenticator : IRemoteServiceHttpClientAuthenticator, ISingletonDependency
    {
        private string accessToken { set; get; }
        public IIdentityModelAuthenticationService _authenticator { set; get; }
        public Task Authenticate(RemoteServiceHttpClientAuthenticateContext context)
        {
            HttpClient httpClient = context.Client;
            //bool flag = _authenticator.TryAuthenticateAsync(httpClient, "OrderService").Result;
            bool flag = _authenticator.TryAuthenticateAsync(httpClient).Result;

            // 2、使用accessToken
            //context.Client.SetBearerToken(accessToken);
            // 1、创建accessToken
            /*if (string.IsNullOrEmpty(accessToken))
            {
                IdentityClientConfiguration identityClient = new IdentityClientConfiguration();
                identityClient.Authority = "https://localhost:44315";
                identityClient.ClientId = "OrderDetailService-Client";
                identityClient.ClientSecret = "123456";
                identityClient.GrantType = "client_credentials";
                accessToken = _authenticator.GetAccessTokenAsync(identityClient).Result;
            }*/
            IdentityClientConfiguration identityClient = new IdentityClientConfiguration();
            return Task.CompletedTask;
        }
    }
}
