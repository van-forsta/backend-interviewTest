using Confirmit.DotNetInterview.Api.Models;
using System.Collections.Generic;

namespace Confirmit.DotNetInterview.Api.Data
{
    public static class StaticDataStore
    {
        public static List<Product> Products { get; } = new List<Product>();
        public static List<Order> Orders { get; } = new List<Order>();
    }
}
