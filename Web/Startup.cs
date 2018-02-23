using Domain.Service;
using Domain.UtilDomain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Code;

namespace Web
{
    /// <summary>
    /// 启动项
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services">services</param>
        public void ConfigureServices(IServiceCollection services)
        {

            // 初始化数据库结构和表结构
            Factory.EnsureCreated();

            // Microsoft SQL Server implementation of IDistributedCache.
            // Note that this would require setting up the session state database.
            //.net core提供了储存在数据库中的配置
            //首先，需要通过cmd指令生成session数据库，生成数据库字段为Id，Value，ExpiresAtTime，SlidingExpirationInSeconds，AbsoluteExpiration

            IConfiguration configuration = Configuration.GetConfigurationRootByJson("config.json");
            services.AddDistributedSqlServerCache(o =>
            {
                o.ConnectionString = configuration["ConnectionString"];
                o.SchemaName = configuration["SessionSchemaName"];
                o.TableName = configuration["SessionTableName"];
            });
            services.AddSession();

            //services.AddTransient<ISiteContract, SiteService>();

            // 注册MVC
            services.AddMvc(options =>
            {
                // 注册json转实体对象
                //options.ModelBinderProviders.Insert(0, new JObjectModelBinderProvider());
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">app</param>
        /// <param name="env">env</param>
        /// <param name="loggerFactory">loggerFactory</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 注册过滤器
            app.UseStaticFiles();

            // 注册HttpContext
            app.UseStaticHttpContext();

            // 注册Session 必须在 UseMvc 之前调用
            app.UseSession();

            // 注册路由
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}