using LKN.Microservices.ClientHttps;
using LKN.Order;
using LKN.Product;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace LKN.EbusinessWebSite
{
    [DependsOn(typeof(AbpAspNetCoreMvcModule))]
    [DependsOn(typeof(AbpAutofacModule))]
    [DependsOn(typeof(ClientHttpsModule))]

    [DependsOn(typeof(OrderHttpApiClientModule))]
    [DependsOn(typeof(ProductHttpApiClientModule))]
    public class EbusinessWebSiteModule: AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            context.Services.AddControllersWithViews();

            context.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
                .AddCookie("Cookies", options =>
                {
                    options.ExpireTimeSpan = TimeSpan.FromDays(365);
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = "https://localhost:44386";
                    options.ClientId = "EbusinessWebSite-Client";
                    options.ClientSecret = "12345";
                    options.RequireHttpsMetadata = false;
                    options.ResponseType = OpenIdConnectResponseType.Code;
                    options.SaveTokens = true;// Token（身份证）
                    options.Scope.Add("openid");
                    options.Scope.Add("profile");
                    options.Scope.Add("OrderService");
                    options.Scope.Add("InternalGateway");
                });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            // 2、开启身份验证(开启登录认证)
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }
}
