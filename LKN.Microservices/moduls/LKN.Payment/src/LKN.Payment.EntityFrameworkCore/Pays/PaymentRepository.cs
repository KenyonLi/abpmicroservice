using LKN.Payment.EntityFrameworkCore;
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
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace LKN.Payment.Pays
{
    /// <summary>
    /// 商品仓储实现
    /// </summary>
    [Dependency(ServiceLifetime.Transient)]
    public class PaymentRepository : EfCoreRepository<PaymentDbContext, Payments, Guid>, IPaymentRepository
    {
        public PaymentRepository(
            IDbContextProvider<PaymentDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
