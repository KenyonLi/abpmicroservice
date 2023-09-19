using AutoMapper;
using LKN.Order.Orders;
using Volo.Abp.Application.Dtos;

namespace LKN.Order;

public class OrderApplicationAutoMapperProfile : Profile
{
    public OrderApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        // Order 映射到   OrderDto(目录)
        //输出
        CreateMap<LKN.Order.Orders.Order, OrderDto>();
        CreateMap<OrderItem, OrderItemDto>();

        //输入
        CreateMap<CreateOrderDto, LKN.Order.Orders.Order>();
        CreateMap<CreateOrderItemDto, OrderItem>();
        CreateMap<UpdateOrderDto, LKN.Order.Orders.Order>();
    }
}
