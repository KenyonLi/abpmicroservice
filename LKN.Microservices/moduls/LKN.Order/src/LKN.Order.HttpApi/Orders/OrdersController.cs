using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Servicecomb.Saga.Omega.Abstractions.Transaction;
using Microsoft.AspNetCore.Authorization;

namespace LKN.Order.Orders;

[RemoteService]
[Route("api/OrderService/order")]
public class OrdersController : OrderController, IOrderAppService
{
    private readonly IOrderAppService _OrderAppService;
    private readonly IConfiguration _configuration;
    private readonly ILogger<OrdersController> _logger;

    public OrdersController(IOrderAppService OrderAppService, IConfiguration configuration, ILogger<OrdersController> logger)
    {
        _OrderAppService = OrderAppService;
        _configuration = configuration;
        _logger = logger;

    }

    [HttpGet("{id}")]
    [Authorize("select")] // 校验身份证
    public async Task<OrderDto> GetAsync(Guid id)
    {
        return await _OrderAppService.GetAsync(id);
    }

    [HttpPost/*,Compensable(nameof(DeleteOrder))*/]
    public async Task<OrderDto> CreateAsync(CreateOrderDto input)
    {
        _logger.LogInformation("创建订单");
        return await _OrderAppService.CreateAsync(input);
    }

    /// <summary>
    /// 1、删除订单方法
    /// 抛出了，会进行重复的执行，直到成功，使用的是幂等机制
    /// </summary>
    /// <param name="input"></param>
    void DeleteOrder(CreateOrderDto input)
    {
        _logger.LogInformation("删除订单");
        //throw new Exception("21221");
        //使用数据库本地事务
        // UnitofWork
        // cap是异步请求，同步
        _OrderAppService.DeleteAsync(input.Id).Wait();
    }

    /// <summary>
    /// 异步创建订单
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    [NonAction]
    public async Task<OrderDto> CreateOrder(CreateOrderDto input)
    {
        Console.WriteLine("异步创建订单");
        return await _OrderAppService.CreateAsync(input);
    }

    [HttpGet("List")]
    public Task<PagedResultDto<OrderDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        throw new NotImplementedException();
    }

    [HttpPut]
    public Task<OrderDto> UpdateAsync(Guid id, UpdateOrderDto input)
    {
        throw new NotImplementedException();
    }
    [HttpDelete]
    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
