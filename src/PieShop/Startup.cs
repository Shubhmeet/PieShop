using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PieShop.Models;

namespace PieShop
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //dependency injection
            services.AddTransient<ICategoryRepository, MockCategoryRepository>();
            services.AddTransient<IPieRepository, MockPieRepository>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            // for showing user defined errors
            app.UseDeveloperExceptionPage();
            //allows to handle status code bw 400-600
            app.UseStatusCodePages();
            //server static files
            app.UseStaticFiles();
            //adding support for mvc, basic route 
            app.UseMvcWithDefaultRoute();
        }
    }
}
