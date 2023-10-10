using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.DependencyInjection;

namespace LKN.Payment.Pays
{
    /// <summary>
    /// 订单服务实现
    /// </summary>
    [RemoteService(IsEnabled = false)]
    public class PaymentAppService : CrudAppService<
                                            Payments,
                                            PaymentDto,
                                            Guid,
                                            PagedAndSortedResultRequestDto,
                                            CreatePaymentDto,
                                            UpdatePaymentDto>, IPaymentAppService
    {
        public IPaymentRepository _paymentRepository;

        public PaymentAppService(IPaymentRepository repository)
            : base(repository)
        {
            this._paymentRepository = repository;
        }

        /// <summary>
        /// 接受创建订单的事件
        /// </summary>
        /// <param name="createOrderDto"></param>
        //[CapSubscribe("OrderService.#")]
       // [CapSubscribe("OrderService.CreateOrder")]
        public void CreateOrderEvent(string orderDto)
        {
            Console.WriteLine($"创建支付：{orderDto}");
            // throw new Exception("创建订单失败");
            // var orderDto = this.CreateAsync(createOrderDto).Result;
            Console.WriteLine($"创建支付成功：{orderDto}");
        }

        /*public override Task<PaymentDto> CreateAsync(CreatePaymentDto input)
        {
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(Guid id)
        {
            return base.DeleteAsync(id);
        }

        public override Task<PaymentDto> GetAsync(Guid id)
        {
            return base.GetAsync(id);
        }

        public override Task<PagedResultDto<PaymentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return base.GetListAsync(input);
        }

        public override Task<PaymentDto> UpdateAsync(Guid id, UpdatePaymentDto input)
        {
            return base.UpdateAsync(id, input);
        }

        protected override Task DeleteByIdAsync(Guid id)
        {
            return base.DeleteByIdAsync(id);
        }*/
    }
}
