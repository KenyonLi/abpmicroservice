using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Nodes;
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
        public IHttpContextAccessor _accessor { set; get; }
        public Task Authenticate(RemoteServiceHttpClientAuthenticateContext context)
        {

            HttpClient httpClient = context.Client;

            //1、使用accessToken
            try
            {
                accessToken = _accessor.HttpContext.GetTokenAsync("access_token").Result;
            }
            catch (Exception)
            {
                // 不作异常处理
                accessToken = "";
            }

            if (!string.IsNullOrEmpty(accessToken))
            {
                httpClient.SetBearerToken(accessToken);
                return Task.CompletedTask;
            }
            //Task.WaitAll();
            //1、使用 配置文件获取token
            //bool flag = _authenticator.TryAuthenticateAsync(httpClient, "OrderService").Result;
            bool flag = _authenticator.TryAuthenticateAsync(httpClient).Result;

            return Task.CompletedTask;
        }
    }
}
