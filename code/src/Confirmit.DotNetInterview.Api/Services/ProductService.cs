using Confirmit.DotNetInterview.Api.Data;
using Confirmit.DotNetInterview.Api.Models;
using Confirmit.DotNetInterview.Api.Util;
using System.Collections.Generic;
using System.Linq;

namespace Confirmit.DotNetInterview.Api.Services
{
    public interface IProductService
    {
        Product Add(Product newProduct);
        List<Product> GetList();
        Product GetSingle(int id);
    }

    public class ProductService : IProductService
    {
        private readonly KeyGenerator _keyGenerator = new KeyGenerator();

        public ProductService()
        {
            Add(new Product() { Name = "GalaxyNote7", Price = 10.0, Weight = 1.25 });
            Add(new Product() { Name = "IPhone7", Price = 20.0, Weight = 1.10 });
        }

        public Product Add(Product newProduct)
        {
            newProduct.Id = _keyGenerator.Generate();
            StaticDataStore.Products.Add(newProduct);

            return newProduct;
        }

        public List<Product> GetList() => StaticDataStore.Products;

        public Product GetSingle(int id) => StaticDataStore.Products.Single(p => p.Id == id);
    }
}
