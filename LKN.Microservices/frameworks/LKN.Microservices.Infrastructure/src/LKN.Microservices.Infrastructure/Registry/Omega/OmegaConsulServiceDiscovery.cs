﻿using Autofac.Core;
using Consul;
using LKN.Microservices.Infrastructure.Registry.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKN.Microservices.Infrastructure.Registry.Omega
{
    /// <summary>
    /// Omega consul服务发现实现
    /// </summary>
    public class OmegaConsulServiceDiscovery : IServiceDiscovery
    {
        private readonly IConfiguration configuration;
        public OmegaConsulServiceDiscovery(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<ServiceNode> Discovery(string serviceName)
        {
           
            ServiceDiscoveryConfig serviceDiscoveryConfig = configuration.GetSection("ConsulDiscovery").Get<ServiceDiscoveryConfig>();

            // 1、创建consul客户端连接
            var consulClient = new ConsulClient(configuration =>
            {
                //1.1 建立客户端和服务端连接
                configuration.Address = new Uri(serviceDiscoveryConfig.RegistryAddress);
            });

            // 2、consul查询服务,根据具体的服务名称查询
            var queryResult = consulClient.Catalog.Service(serviceName).Result;

            // 3、将服务进行拼接
            var list = new List<ServiceNode>();
            foreach (var service in queryResult.Response)
            {
                // alpha-server-host=localhost
                // alpha-server-port=8010
                string[] tags = service.ServiceTags;
                // 3.1 截取alpha-server-host
                string hostTag = tags[0];
                string host = hostTag.Split("=")[1];
                string portTag = tags[1];
                string port = portTag.Split("=")[1];
                list.Add(new ServiceNode { Url = host + ":" + port });
            }
            return list;
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
