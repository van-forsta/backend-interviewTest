using Confirmit.DotNetInterview.Api.Data;
using Confirmit.DotNetInterview.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confirmit.DotNetInterview.Api.Services
{
    public interface IOrderCostEstimationService
    {
        Order EstimateCost(Order order);
    }

    public class OrderCostEstimationService : IOrderCostEstimationService
    {
        private readonly IProductService _productService;

        public OrderCostEstimationService(IProductService productService)
        {
            _productService = productService;
        }

        public Order EstimateCost(Order order)
        {
            var productCost = order.LineItems.Aggregate(0.0,
                (cost, item) => cost += item.Quantity * _productService.GetSingle(item.ProductId).Price);

            order.ProductCost = productCost;
            order.ShippingCost = 0;

            return order;
        }
    }
}
