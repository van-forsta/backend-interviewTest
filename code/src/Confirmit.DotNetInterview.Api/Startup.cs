using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Prometheus;

namespace Confirmit.DotNetInterview.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                services.AddOptions();
                services.AddControllers(config =>
                    {
                        config.ConfigureLocalMvcOptions();
                    })
                    .AddNewtonsoftJson(config =>
                    {
                        config.ConfigureLocalMvcJsonOptions();
                    })
                    .AddLocalMvc(Configuration);
                services.AddHttpContextAccessor();
                services.AddLocalServices(Configuration);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // ReSharper disable once UnusedMember.Global
        public void Configure(IApplicationBuilder builder, IWebHostEnvironment env)
        {
            try
            {
                builder.UseRouting();
                builder.UseLocalConfiguration(env);
                if (env.IsDevelopment())
                    builder.UseDeveloperExceptionPage();
                builder.UseEndpoints(config =>
                {
                    config.MapControllers();
                    config.ConfigureEndpoints();
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
