﻿using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.ApiScopes;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.Devices;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.IdentityServer.Grants;
using Volo.Abp.IdentityServer.IdentityResources;

namespace LKN.AuthMicroService.EntityFrameworkCore;

[ConnectionStringName(AuthMicroServiceDbProperties.ConnectionStringName)]
[ReplaceDbContext(typeof(IIdentityServerDbContext))]// 替换IIdentityServerDbContext
public class AuthMicroServiceDbContext : AbpDbContext<AuthMicroServiceDbContext>,
    IAuthMicroServiceDbContext, IIdentityServerDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public AuthMicroServiceDbContext(DbContextOptions<AuthMicroServiceDbContext> options)
        : base(options)
    {

    }
    #region ApiResource

    public DbSet<ApiResource> ApiResources { get; set; }

    public DbSet<ApiResourceSecret> ApiResourceSecrets { get; set; }

    public DbSet<ApiResourceClaim> ApiResourceClaims { get; set; }

    public DbSet<ApiResourceScope> ApiResourceScopes { get; set; }

    public DbSet<ApiResourceProperty> ApiResourceProperties { get; set; }

    #endregion

    #region ApiScope

    public DbSet<ApiScope> ApiScopes { get; set; }

    public DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }

    public DbSet<ApiScopeProperty> ApiScopeProperties { get; set; }

    #endregion

    #region IdentityResource

    public DbSet<IdentityResource> IdentityResources { get; set; }

    public DbSet<IdentityResourceClaim> IdentityClaims { get; set; }

    public DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }

    #endregion

    #region Client

    public DbSet<Client> Clients { get; set; }

    public DbSet<ClientGrantType> ClientGrantTypes { get; set; }

    public DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }

    public DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }

    public DbSet<ClientScope> ClientScopes { get; set; }

    public DbSet<ClientSecret> ClientSecrets { get; set; }

    public DbSet<ClientClaim> ClientClaims { get; set; }

    public DbSet<ClientIdPRestriction> ClientIdPRestrictions { get; set; }

    public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }

    public DbSet<ClientProperty> ClientProperties { get; set; }

    #endregion

    public DbSet<PersistedGrant> PersistedGrants { get; set; }

    public DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }

    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureAuthMicroService();
    }
}
