using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace LKN.Payment.Pays
{
    /// <summary>
    /// 订单应用服务接口
    /// </summary>
    public interface IPaymentAppService : ICrudAppService<
                                            PaymentDto, 
                                            Guid, 
                                            PagedAndSortedResultRequestDto,
                                            CreatePaymentDto,
                                            UpdatePaymentDto>
    {


    }
}
