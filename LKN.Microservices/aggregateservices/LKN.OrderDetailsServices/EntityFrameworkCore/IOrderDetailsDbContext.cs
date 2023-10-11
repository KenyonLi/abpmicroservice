using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace LKN.OrderDetailsServices.EntityFrameworkCore
{
    [ConnectionStringName("OrderDetails")]
    public interface IOrderDetailsDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}
