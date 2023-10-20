using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace LKN.AuthMicroService.EntityFrameworkCore;

public class AuthMicroServiceHttpApiHostMigrationsDbContext : AbpDbContext<AuthMicroServiceHttpApiHostMigrationsDbContext>
{
    public AuthMicroServiceHttpApiHostMigrationsDbContext(DbContextOptions<AuthMicroServiceHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // 1、去掉IdentityServer4前缀
        AbpIdentityServerDbProperties.DbTablePrefix = "";
        // 去掉
        AbpIdentityDbProperties.DbTablePrefix = "";
        AbpPermissionManagementDbProperties.DbTablePrefix = "";


        base.OnModelCreating(modelBuilder);

        // 2、创建用户表
        modelBuilder.ConfigureAuthMicroService();
        //创建用户表
        modelBuilder.ConfigureIdentity(); 
        //权限表
        modelBuilder.ConfigurePermissionManagement();
    }
}
