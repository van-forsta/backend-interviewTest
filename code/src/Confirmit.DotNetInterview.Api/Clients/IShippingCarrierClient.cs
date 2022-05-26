using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confirmit.DotNetInterview.Api.Clients
{
    public interface IShippingCarrierClient
    {
        [Get("/shippingcarriers")]
        Task<ApiResponse<string[]>> GetList();
    }
}
