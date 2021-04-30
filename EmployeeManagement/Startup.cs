using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            MvcOptions mvcMyOpts = new MvcOptions
            {
                EnableEndpointRouting = false
            };
            //services.AddMvc(Action < mvcMyOpts > true);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //,ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseRouting();

            //app.Use(async (context,next1ubugger) =>
            //{
            //    logger.LogInformation("MW1: Incoming Request");
            //    await context.Response.WriteAsync("hello from 1\n");
            //    await next1ubugger();
            //    logger.LogInformation("MW1: Outgoing Response");
            //});

            //app.Use(async (context, next1ubugger) =>
            //{
            //    logger.LogInformation("MW2: Incoming Request");
            //    await context.Response.WriteAsync("hello from 1");
            //    await next1ubugger();
            //    logger.LogInformation("MW2: Outgoing Response");
            //});

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World");
                //logger.LogInformation("MW3: Request handled");
            });
        }
    }
}
