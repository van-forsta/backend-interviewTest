using System.Collections.Generic;

namespace Confirmit.DotNetInterview.Api.Models
{
    public class Order
    {
        public int Id { get; set; }
        public ShippingCarriers ShippingCarrier { get; set; }
        public List<OrderLineItem> LineItems { get; set; } = new List<OrderLineItem>();
        public double ProductCost { get; set; }
        public double ShippingCost { get; set; }
        public double TotalCost => ProductCost + ShippingCost;
    }
}
