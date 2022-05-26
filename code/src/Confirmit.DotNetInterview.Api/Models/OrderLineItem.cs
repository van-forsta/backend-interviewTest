namespace Confirmit.DotNetInterview.Api.Models
{
    public class OrderLineItem
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
