using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp;

namespace LKN.Payment.Pays
{
    /// <summary>
    /// 订单控制器
    /// </summary>
    [RemoteService]
    [Route("/api/PaymentService/payment")]
    public class PaymentsController : PaymentController, IPaymentAppService
    {
        private readonly IPaymentAppService _PaymentAppService;

        public PaymentsController(IPaymentAppService PaymentAppService)
        {
            _PaymentAppService = PaymentAppService;
        }

        [HttpPost]
        public async Task<PaymentDto> CreateAsync(CreatePaymentDto input)
        {
            PaymentDto paymentDto = await _PaymentAppService.CreateAsync(input);
            return paymentDto;
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public Task<PaymentDto> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public Task<PagedResultDto<PaymentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public Task<PaymentDto> UpdateAsync(Guid id, UpdatePaymentDto input)
        {
            throw new NotImplementedException();
        }
    }
}
