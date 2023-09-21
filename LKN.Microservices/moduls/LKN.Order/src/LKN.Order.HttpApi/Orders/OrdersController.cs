using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;

namespace LKN.Order.Orders;
[Area(OrderRemoteServiceConsts.ModuleName)]
[RemoteService(Name = OrderRemoteServiceConsts.RemoteServiceName)]
[Route("api/OrderService/ord")]
[ApiController]
public class OrdersController : OrderController, IOrderAppService
{
    private readonly IOrderAppService _OrderAppService;

    public OrdersController(IOrderAppService OrderAppService)
    {
        _OrderAppService = OrderAppService;
    }

    [HttpGet("{id}")]
    public async Task<OrderDto> GetAsync(Guid id)
    {
        return await _OrderAppService.GetAsync(id);
    }

    [HttpPost]
    public async Task<OrderDto> CreateAsync(CreateOrderDto input)
    {
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
