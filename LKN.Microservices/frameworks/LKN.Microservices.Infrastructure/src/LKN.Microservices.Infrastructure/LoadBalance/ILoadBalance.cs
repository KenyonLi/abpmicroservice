using LKN.Microservices.Infrastructure.Registry;
using System;
using System.Collections.Generic;
using System.Text;

namespace LKN.MicroService.Core.Cluster
{
    /// <summary>
    /// 服务负载均衡
    /// </summary>
    public interface ILoadBalance
    {
        /// <summary>
        /// 服务选择
        /// </summary>
        /// <param name="serviceUrls"></param>
        /// <returns></returns>
        ServiceNode Select(IList<ServiceNode> serviceUrls);
    }
}
