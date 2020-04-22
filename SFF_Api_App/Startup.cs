using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using SFF_Api_App.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;

namespace SFF_Api_App
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlite().AddDbContext<SFF_DbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();

            /*
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "LoginView",
                    template: "{controller=User}/{action=LoginView}/{id?}");
            });
            */
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");
            });
        }
    }
}
