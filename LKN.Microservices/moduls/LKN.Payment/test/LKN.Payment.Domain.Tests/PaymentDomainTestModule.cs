using LKN.Payment.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LKN.Payment;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(PaymentEntityFrameworkCoreTestModule)
    )]
public class PaymentDomainTestModule : AbpModule
{

}
