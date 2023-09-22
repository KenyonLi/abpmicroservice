using LKN.Order.Registrys;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LKN.Order
{
    /// <summary>
    ///  服务注册IOC容器扩展
    /// </summary>
    public static class ServiceRegistryServiceCollectionExtensions
    {
        // consul服务注册
        public static IServiceCollection AddServiceRegistry(this IServiceCollection services)
        {
            AddServiceRegistry(services, optons => { });
            return services;
        }

        // consul服务注册
        public static IServiceCollection AddServiceRegistry(this IServiceCollection services, Action<ServiceRegistryOptions> options)
        {
            // 1、配置选项到IOC
            services.Configure<ServiceRegistryOptions>(options);

            // 2、注册consul注册
            services.AddSingleton<ConsulServiceRegistry>();

            // 3、注册开机自动注册服务
            services.AddHostedService<ServiceRegistryIHostedService>();

            return services;
        }
    }
}
