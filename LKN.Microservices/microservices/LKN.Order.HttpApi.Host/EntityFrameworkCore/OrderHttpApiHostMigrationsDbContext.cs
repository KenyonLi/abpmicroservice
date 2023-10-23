using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace LKN.Order.EntityFrameworkCore;

public class OrderHttpApiHostMigrationsDbContext : AbpDbContext<OrderHttpApiHostMigrationsDbContext>
{
    public OrderHttpApiHostMigrationsDbContext(DbContextOptions<OrderHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //去掉前缀
        AbpPermissionManagementDbProperties.DbTablePrefix = "";
       
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureOrder();
        modelBuilder.ConfigurePermissionManagement();//添加权限管理表
    }
}
