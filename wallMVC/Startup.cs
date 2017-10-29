using System;
using System.Linq;
using DbConnection;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace scaffold
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; private set;}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services to make stuff (OBJECTS and maybe more) project-able-y available
            // Read more about dependency injection and design patterns https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection 
            services.AddMvc();
            services.AddSession();
            // The MySqlOptions object was created in the Properties folder. 
            // How it's related to the configure method and the Configuration.GetSection eludes
            // Current assumption, Configuration appsettings.json for objects with ("STRING NAME")
            services.Configure<MySqlOptions>(Configuration.GetSection("DBInfo"));
            services.AddScoped<UserFactory>();
            services.AddScoped<MessageFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
        }
    }
}
