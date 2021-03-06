﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebApplication1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseDirectoryBrowser();
            //app.UseFileServer();
            //app.UseStaticFiles();

            /*
            if (env.IsDevelopment())
            {
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync("This is Development!");
                });
            } 
            else 
            {
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync("And this is Production!");
                });
            }  
            */
            
            {
                app.Run(async (context) =>
                {
                    await context.Response.WriteAsync($"This is {env.EnvironmentName}"); //way better than the if else statement above
                });
            }
        }
    }
}
