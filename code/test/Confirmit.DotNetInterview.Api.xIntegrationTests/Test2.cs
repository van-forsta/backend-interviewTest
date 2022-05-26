using Confirmit.DotNetInterview.Api.Clients;
using Confirmit.DotNetInterview.Api.Models;
using Confirmit.DotNetInterview.Api.xIntegrationTests.Fixtures;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Confirmit.DotNetInterview.Api.xIntegrationTests
{
    public class Test2 : InMemoryServiceTestBase
    {
        public Test2(ITestOutputHelper helper, InMemoryServiceFixture fixture) : base(helper, fixture)
        {
        }

        ///////////////////////////////////////////////////////////////////////////
        //  5. Use the order post API endpoint to place an order 
        //     with 1 IPhone7 and 1 GalaxyNote7. Assert that the result 
        //     has a ProductCost of 30 and an Id of 1. 
        ///////////////////////////////////////////////////////////////////////////
        [Fact]
        public void PostOrder_ProductCost30_OrderIPhone7GalaxyNote7()
        {
            var order = new Order();
            //...
            Assert.Equal(30, order.ProductCost);
            Assert.Equal(1, order.Id);
        }

        ///////////////////////////////////////////////////////////////////////////
        //  6. Use the order post API endpoint to place an order. 
        //     Place an order with 2x IPhone7, 3x GalaxyNote7, and Usps shipping. 
        //     The equation for Usps shipping cost is
        //     based on the product weight, as follows:
        //
        //     Usps shippingCost = 1 + (1.5 * WeightOfProducts).
        //
        //     All other carriers have a flat cost of 10. 
        //  
        //     Implement the shipping cost calculations using the strategy pattern.
        //     Select the appropriate strategy by utilizing the factory pattern.
        //     The interfaces are already definied: 
        //     IShippingCostStrategyFactory, IShippingCostStrategy.
        //     Remember to register your implementation of the 
        //     IShippingCostStrategyFactory with the IoC container.
        //     This is configured in startup.cs.
        //   
        //     The order's TotalCost field should be 89.7.
        ///////////////////////////////////////////////////////////////////////////
        [Fact]
        public void PostOrder_TotalCost89p7_Order2xGalaxyNote7And3xIPhone7()
        {
            var order = new Order();
            //...
            Assert.Equal(89.7, order.TotalCost);
        }

        ///////////////////////////////////////////////////////////////////////////
        // 7. Add .NET Core policy-based authorization to this API.
        //    Use the AuthRequirement and AuthHandler already defined in code.
        //    Create two auth policies, one for read access and one for write access.
        //    Apply the read access policy to all GET endpoints.
        //    Apply the write access policy to all other endpoints.
        //    Ensure the clients send the correct auth header(s).
        //    For the test below, confirm the Product endpoints respond with 403
        //    if the client doesn't have credentials
        ////////////////////////////////////////////////////////////////////////////
        [Fact]
        public async Task Products_AuthFailsIfRequestNotValid()
        {
            var client = GetRestClient<IProductClient>();

            // Test with a request that fails auth completely
            var getResponse = await client.GetList();
            Assert.Equal(HttpStatusCode.Forbidden, getResponse.StatusCode);

            // Test with a request that has no write access
            var newProductResponse = await client.Post(new Product
            {
                Name = "Unauthorized Phone",
                Weight = 0.6,
                Price = 2.0
            });
            Assert.Equal(HttpStatusCode.Forbidden, newProductResponse.StatusCode);
        }
    }
}
