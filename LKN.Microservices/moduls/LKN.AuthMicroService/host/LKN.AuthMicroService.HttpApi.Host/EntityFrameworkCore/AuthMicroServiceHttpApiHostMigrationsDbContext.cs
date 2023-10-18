using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer;

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
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureAuthMicroService();// IdentityServer4表

        // 2、创建用户表
        modelBuilder.ConfigureIdentity(); // 创建用户表
    }
}
