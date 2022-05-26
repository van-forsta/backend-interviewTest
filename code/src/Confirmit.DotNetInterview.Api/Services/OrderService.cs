using Confirmit.DotNetInterview.Api.Data;
using Confirmit.DotNetInterview.Api.Models;
using Confirmit.DotNetInterview.Api.Util;
using System.Collections.Generic;
using System.Linq;

namespace Confirmit.DotNetInterview.Api.Services
{
    public interface IOrderService
    {
        Order Create(Order newOrder);
        Order Get(int id);
    }

    public class OrderService : IOrderService
    {
        private readonly KeyGenerator _keyGenerator = new KeyGenerator();

        public Order Create(Order newOrder)
        {
            newOrder.Id = _keyGenerator.Generate();
            StaticDataStore.Orders.Add(newOrder);
            
            return newOrder;
        }

        public Order Get(int id)
            => StaticDataStore.Orders.SingleOrDefault(o => o.Id == id);
    }
}
