using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Caching.SqlServer;

namespace Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Microsoft SQL Server implementation of IDistributedCache.
            // Note that this would require setting up the session state database.
            //.net core提供了储存在数据库中的配置
            //首先，需要通过cmd指令生成session数据库，生成数据库字段为Id，Value，ExpiresAtTime，SlidingExpirationInSeconds，AbsoluteExpiration
            services.AddDistributedSqlServerCache(o =>
            {
                o.ConnectionString = "Server=.;Database=ASPNET5SessionState;Trusted_Connection=True;";
                o.SchemaName = "dbo";
                o.TableName = "Sessions";
            });
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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