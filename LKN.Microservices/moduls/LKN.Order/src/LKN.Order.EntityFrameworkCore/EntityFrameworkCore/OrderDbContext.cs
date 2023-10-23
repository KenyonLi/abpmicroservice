using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace LKN.Order.EntityFrameworkCore;

[ConnectionStringName(OrderDbProperties.ConnectionStringName)]
[ReplaceDbContext(typeof(IPermissionManagementDbContext))]
public class OrderDbContext : AbpDbContext<OrderDbContext>, ISingletonDependency,IOrderDbContext, IPermissionManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */
    public DbSet<LKN.Order.Orders.Order> Order { get; set; } // 配置订单领域(以领域为单位)

    public DbSet<PermissionGroupDefinitionRecord> PermissionGroups { get; set; }

    public DbSet<PermissionDefinitionRecord> Permissions { get; set; }

    public DbSet<PermissionGrant> PermissionGrants { get; set; }


    public OrderDbContext(DbContextOptions<OrderDbContext> options)
        : base(options)
    {

    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ConfigureOrder();
    }
}
