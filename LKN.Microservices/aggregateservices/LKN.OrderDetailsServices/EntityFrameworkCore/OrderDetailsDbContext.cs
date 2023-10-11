using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace LKN.OrderDetailsServices.EntityFrameworkCore
{
    [ConnectionStringName("OrderDetails")]
    public class OrderDetailsDbContext : AbpDbContext<OrderDetailsDbContext>, IOrderDetailsDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */

        public OrderDetailsDbContext(DbContextOptions<OrderDetailsDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
