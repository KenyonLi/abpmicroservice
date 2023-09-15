using LKN.Order.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LKN.Order;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(OrderEntityFrameworkCoreTestModule)
    )]
public class OrderDomainTestModule : AbpModule
{

}
