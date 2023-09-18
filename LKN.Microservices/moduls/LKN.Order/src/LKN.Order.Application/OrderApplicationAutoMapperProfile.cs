using AutoMapper;
using LKN.Order.Orders;

namespace LKN.Order;

public class OrderApplicationAutoMapperProfile : Profile
{
    public OrderApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<CreateOrderDto, LKN.Order.Orders.Order>();
        CreateMap<CreateOrderItemDto, OrderItem>();
        CreateMap<Orders.Order, OrderDto>();
        CreateMap<OrderItem, OrderItemDto>();
        CreateMap<UpdateOrderDto, Orders.Order>();
    }
}
