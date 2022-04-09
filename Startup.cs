using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Prr_stakan.Data.interfaces;
using Prr_stakan.Data.mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prr_stakan
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IAllBooks, MockBooks>();
            services.AddTransient<IBooksCats, MockCategory>();
            services.AddTransient<IBookYears, MockYears>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //app.UseMvcWithDefaultRoute();
            app.UseMvc(routs =>
            {
                routs.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
                routs.MapRoute(name: "catFilter", template: "Books/{action}/{category?}",defaults : new {Controller="Books",action="List" });
                routs.MapRoute(name: "eachBook", template: "Books/{action}/{id?}", defaults: new { Controller = "Books", action = "ShowEach" });
            });
        }
    }
}
