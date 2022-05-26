using Confirmit.DotNetInterview.Api.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confirmit.DotNetInterview.Api
{
    public static partial class StartupExtensions
    {
        static partial void AddLocalServicesImpl(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton<IOrderCostEstimationService, OrderCostEstimationService>();
        }
    }
}
