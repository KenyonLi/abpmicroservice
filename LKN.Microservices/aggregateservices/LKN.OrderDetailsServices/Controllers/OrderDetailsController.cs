using DotNetCore.CAP;
using LKN.Order.Orders;
using LKN.Payment.Pays;
using LKN.Product.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicecomb.Saga.Omega.Abstractions.Transaction;
using System.Threading;

namespace LKN.OrderDetailsServices.Controllers
{
    /// <summary>
    /// 订单详情控制器
    /// </summary>
    [ApiController]
    [Route("api/OrderDetailsServices/OrderDetails")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly ILogger<OrderDetailsController> _logger;

        public IProductAppService _ProductAppService { set; get; }
        public IOrderAppService _OrderAppService { set; get; }
        public IPaymentAppService _paymentAppService { set; get; } // 属性依赖注入

        public ICapPublisher _capPublisher { set; get; } // 发布事件接口

        public OrderDetailsController(ILogger<OrderDetailsController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 获取订单详情
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<OrderDto> Get(Guid id)
        {
            // 1、查询订单
            OrderDto orderDto = await _OrderAppService.GetAsync(id);

            // 2、查询商品
            OrderItemDto[] orderItemDtos = orderDto.OrderItems;
            foreach (var orderItem in orderItemDtos)
            {
                ProductDto productDto = await _ProductAppService.GetAsync(orderItem.ProductId);

                //3、设置商品名称
                orderItem.ProductName = productDto.ProductTitle;
            }
            // 2、查询商品
            return orderDto;
        }

        /// <summary>
        /// 创建订单（事件）===>消息
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreateOrderAsync")]
        public async Task<CreateOrderDto> CreateOrderAsync(CreateOrderDto createOrderDto)
        {
            if (true)
            {
                await _capPublisher.PublishAsync<CreateOrderDto>("OrderService.CreateOrder", createOrderDto);
            }
            // OrderDto orderDto = _OrderAppService.CreateAsync(createOrderDto).Result;

            return createOrderDto;
        }

        /// <summary>
        /// 创建订单
        /// </summary>
        /// <returns></returns>
        // [HttpPost("CreateOrder"), SagaStart]
        [HttpPost("CreateOrder"), SagaStart()] // 开启分布式事务 
        public OrderDto CreateOrder(CreateOrderDto createOrderDto)
        {
            // 1、创建订单
            createOrderDto.Id = Guid.NewGuid();
            OrderDto orderDto = _OrderAppService.CreateAsync(createOrderDto).Result;

            // 2、扣减库存
            string guid = "3a0dbecd-d8bc-b847-4c93-82f82bc0d608";
            UpdateProductDto updateProductDto = new UpdateProductDto();
            updateProductDto.ProductStock = 2;
            updateProductDto.id = Guid.Parse(guid);
            ProductDto productDto = _ProductAppService.Update2Async(updateProductDto).Result;

            // 3、执行失败
            throw new Exception("执行异常");
            return orderDto;
        }

        /// <summary>
        /// 修改订单
        /// </summary>
        /// <returns></returns>
        [HttpPut("CreateOrder")]
        public async Task<UpdateOrderDto> UpdateOrder(UpdateOrderDto updateOrderDto)
        {
            await _capPublisher.PublishAsync<UpdateOrderDto>("OrderService.UpdateOrder", updateOrderDto);
            return updateOrderDto;
        }

        /// <summary>
        /// 创建商品
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreateProduct")]
        public async Task<CreateProductDto> CreateProduct(CreateProductDto createProductDto)
        {
            await _capPublisher.PublishAsync<CreateProductDto>("ProductService.CreateProduct", createProductDto);
            return createProductDto;
        }

        /// <summary>
        /// 删除商品
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<DeleteProductDto> DeleteProduct(DeleteProductDto deleteProductDto)
        {
            await _capPublisher.PublishAsync<DeleteProductDto>("ProductService.DeleteProduct", deleteProductDto);
            return deleteProductDto;
        }

        /// <summary>
        /// 创建支付接口
        /// </summary>
        /// <returns></returns>
        [HttpPost("CreatePayment")]
        public async Task<PaymentDto> CreatePayment(CreatePaymentDto createPaymentDto)
        {
            PaymentDto paymentDto = await _paymentAppService.CreateAsync(createPaymentDto);
            return paymentDto;
        }

    }
}
