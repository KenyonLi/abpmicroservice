using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKN.Microservices.Infrastructure.Registry
{
    /// <summary>
    /// 服务发现配置
    /// </summary>
    public class ServiceDiscoveryConfig
    {
        /// <summary>
        /// 服务注册地址
        /// </summary>
        public string RegistryAddress { set; get; }
    }
}
