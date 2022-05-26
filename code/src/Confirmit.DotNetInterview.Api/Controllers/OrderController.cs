using Confirmit.DotNetInterview.Api.Models;
using Confirmit.DotNetInterview.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confirmit.DotNetInterview.Api.Controllers
{
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IOrderCostEstimationService _orderCostEstimationService;

        public OrderController(IOrderService orderService, IOrderCostEstimationService orderCostEstimationService)
        {
            _orderService = orderService;
            _orderCostEstimationService = orderCostEstimationService;
        }

        [HttpPost]
        public ActionResult<Order> Post(Order newOrder)
        {
            var order = _orderService.Create(newOrder);
            order = _orderCostEstimationService.EstimateCost(order);

            return Ok(order);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return Ok(_orderService.Get(id));
        }
    }
}
