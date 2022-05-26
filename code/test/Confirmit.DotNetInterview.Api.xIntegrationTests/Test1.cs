using Confirmit.DotNetInterview.Api.Clients;
using Confirmit.DotNetInterview.Api.Models;
using Confirmit.DotNetInterview.Api.xIntegrationTests.Fixtures;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Confirmit.DotNetInterview.Api.xIntegrationTests
{
    public class Test1 : InMemoryServiceTestBase
    {
        public Test1(ITestOutputHelper helper, InMemoryServiceFixture fixture) : base(helper, fixture)
        {
        }

        ///////////////////////////////////////////////////////////////////////////
        //  1. Product IDs should start at 1001. 
        ///////////////////////////////////////////////////////////////////////////
        [Fact]
        public async Task ProductGetList_ReturnsAllProductsIdsStartAt1001()
        {
            var client = GetRestClient<IProductClient>();
            var result = await client.GetList();
            Assert.Equal(1001, result.Content.First().Id);
        }

        ///////////////////////////////////////////////////////////////////////////
        //  2. Adding a product without a price or weight results in bad request.
        ///////////////////////////////////////////////////////////////////////////
        [Fact]
        public async Task ProductPost_BadRequest_ProductWithoutPrice()
        {
            var completeProductDescription = new Product
            {
                Name = "Essential Phone",
                Weight = 0.6,
                Price = 2.0
            };
            var noPriceProduct = new Product
            {
                Name = "Free Phone",
                Weight = 0.6
            };
            var noWeightProduct = new Product
            {
                Name = "Weightless Phone",
                Price = 2.0
            };

            var client = GetRestClient<IProductClient>();

            var completeProductDescriptionResult = await client.Post(completeProductDescription);
            var noPriceResult = await client.Post(noPriceProduct);
            var noWeightResult = await client.Post(noWeightProduct);

            Assert.Equal(HttpStatusCode.Created, completeProductDescriptionResult.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, noWeightResult.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, noPriceResult.StatusCode);
        }

        ///////////////////////////////////////////////////////////////////////////
        //  3. Ensure product get single endpoint returns the correct responses
        ///////////////////////////////////////////////////////////////////////////
        [Fact]
        public async Task ProductGetSingle_ReturnsOkOrNotFound()
        {
            var client = GetRestClient<IProductClient>();
            var newProductResponse = await client.Post(new Product
            {
                Name = "New Phone",
                Weight = 0.6,
                Price = 2.0
            });
            var newProduct = newProductResponse.Content;

            var getExistingResponse = await client.GetSingle(newProduct.Id);
            var getNonExistentResponse = await client.GetSingle(int.MaxValue);

            Assert.Equal(HttpStatusCode.OK, getExistingResponse.StatusCode);
            Assert.Equal(HttpStatusCode.NotFound, getNonExistentResponse.StatusCode);
        }

        ///////////////////////////////////////////////////////////////////////////
        //  4. Add API Endpoint to list supported shipping carriers:
        ///////////////////////////////////////////////////////////////////////////
        [Fact]
        public async Task ShippingCarriersGetList_ListOfSupportedCarriers()
        {
            var client = GetRestClient<IShippingCarrierClient>();
            var result = await client.GetList();

            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
            Assert.Equal(new string[] { "Ups", "FedEx", "Dhl", "Usps" }, result.Content);
        }        
    }
}
