using Confirmit.DotNetInterview.Api.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confirmit.DotNetInterview.Api.Clients
{
    public interface IProductClient
    {
        [Post("/products")]
        Task<ApiResponse<Product>> Post(Product newProduct);

        [Get("/products")]
        Task<ApiResponse<List<Product>>> GetList();

        [Get("/products/{id}")]
        Task<ApiResponse<Product>> GetSingle(int id);
    }
}
