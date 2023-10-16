using LKN.MicroService.Core.Cluster;
using LKN.Microservices.Infrastructure.Registry;
using LKN.Microservices.Infrastructure.Registry.Omega;
using Microsoft.Extensions.DependencyInjection;
using Servicecomb.Saga.Omega.AspNetCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKN.Microservices.Infrastructure.sagas
{
    /// <summary>
    /// ServiceCollection分布式事务集群扩展
    /// </summary>
    public static class SagsServiceCollectionExtensions
    {
        public static IServiceCollection AddOmegaCoreCluster(this IServiceCollection services, string omegaServiceName, string ServiceName)
        {
            // 1、注册Omega服务发现
            services.AddSingleton<OmegaConsulServiceDiscovery>();
            ServiceProvider serviceProvider = services.BuildServiceProvider();
            // 2、获取Omega服务发现
            OmegaConsulServiceDiscovery omega = serviceProvider.GetService<OmegaConsulServiceDiscovery>();
            IList<ServiceNode> serviceUrls = omega.Discovery(omegaServiceName);
            // 3、获取负载均衡
            ILoadBalance loadBalance = new RandomLoadBalance();
            ServiceNode serviceUrl = loadBalance.Select(serviceUrls);
            services.AddOmegaCore(option =>
            {
                option.GrpcServerAddress = serviceUrl.Url; // 1、协调中心地址
                option.InstanceId = ServiceName + Guid.NewGuid().ToString();// 2、服务实例Id
                option.ServiceName = ServiceName;// 3、服务名称
            });
            return services;
        }
    }
}
