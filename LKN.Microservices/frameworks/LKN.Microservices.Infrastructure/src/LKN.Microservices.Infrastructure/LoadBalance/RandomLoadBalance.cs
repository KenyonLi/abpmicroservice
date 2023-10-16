﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using LKN.Microservices.Infrastructure.Registry;

namespace LKN.MicroService.Core.Cluster
{
    /// <summary>
    /// 随机负载均衡
    /// 1、还可以实现加权轮询
    /// </summary>
    public class RandomLoadBalance : AbstractLoadBalance
    {
        private readonly Random random = new Random();

        public override ServiceNode DoSelect(IList<ServiceNode> serviceUrls)
        {
            // 1、获取随机数
            var index = random.Next(serviceUrls.Count);

            // 2、选择一个服务进行连接
            return serviceUrls[index];
        }
    }
}