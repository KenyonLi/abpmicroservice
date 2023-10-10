using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Repositories;

namespace LKN.Payment.Pays
{
    /// <summary>
    /// 支付仓储
    /// </summary>
    public interface IPaymentRepository : IRepository<Payments, Guid>
    {

    }
}
