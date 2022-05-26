//==== DO NOT MODIFY THIS FILE ====
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// ReSharper disable PartialMethodWithSinglePart

namespace Confirmit.DotNetInterview.Api
{
    public static partial class StartupExtensions
    {
        public static IServiceCollection AddLocalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLocalServicesImpl(configuration);
            return services;
        }

        public static IApplicationBuilder UseLocalConfiguration(this IApplicationBuilder builder, IWebHostEnvironment environment)
        {
            builder.UseLocalConfigurationImpl(environment);
            return builder;
        }

        public static MvcOptions ConfigureLocalMvcOptions(this MvcOptions options)
        {
            options.ConfigureLocalMvcOptionsImpl();
            return options;
        }

        public static MvcNewtonsoftJsonOptions  ConfigureLocalMvcJsonOptions(this MvcNewtonsoftJsonOptions options)
        {
            options.ConfigureLocalMvcJsonOptionsImpl();
            return options;
        }

        public static IMvcBuilder AddLocalMvc(this IMvcBuilder builder, IConfiguration configuration)
        {
            builder.AddLocalMvcImpl(configuration);
            return builder;
        }

        public static IEndpointRouteBuilder ConfigureEndpoints(this IEndpointRouteBuilder config)
        {
            config.ConfigureEndpointsImpl();
            return config;
        }

        public static IHealthChecksBuilder ConfigureHealthChecks(this IHealthChecksBuilder builder)
        {
            builder.ConfigureHealthChecksImpl();
            return builder;
        }

        /// <summary>
        /// Implement method in partial class
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        static partial void AddLocalServicesImpl(this IServiceCollection services, IConfiguration configuration);

        /// <summary>
        /// Implement method in partial class
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="environment"></param>
        static partial void UseLocalConfigurationImpl(this IApplicationBuilder builder, IWebHostEnvironment environment);

        /// <summary>
        /// Implement method in partial class
        /// </summary>
        /// <param name="options"></param>
        static partial void ConfigureLocalMvcOptionsImpl(this MvcOptions options);

        /// <summary>
        /// Implement method in partial class
        /// </summary>
        /// <param name="options"></param>
        static partial void ConfigureLocalMvcJsonOptionsImpl(this MvcNewtonsoftJsonOptions options);

        /// <summary>
        /// Implement method in partial class
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="configuration"></param>
        static partial void AddLocalMvcImpl(this IMvcBuilder builder, IConfiguration configuration);

        /// <summary>
        /// Implement method in partial class
        /// </summary>
        /// <param name="config"></param>
        static partial void ConfigureEndpointsImpl(this IEndpointRouteBuilder config);

        /// <summary>
        /// Implement method in partial class
        /// </summary>
        /// <param name="builder"></param>
        static partial void ConfigureHealthChecksImpl(this IHealthChecksBuilder builder);
    }
}