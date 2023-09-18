﻿using AutoMapper.Internal.Mappers;
using LKN.Order.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LKN.Order.Orders
{
    /// <summary>
    /// 订单服务实现
    /// </summary>
    public class OrdderAppService : CrudAppService<
        Order,
        OrderDto,
        Guid,
        PagedAndSortedResultRequestDto,
        CreateOrderDto,
        UpdateOrderDto>
        , IOrderAppService
    {
        public IOrderRepository _orderRepository;

        public OrdderAppService(IOrderRepository repository) : base(repository)
        {
            _orderRepository = repository;
        }
    }
}
