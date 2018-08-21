using Order.IntegrationTests.Helpers;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Order.IntegrationTests
{
    public class OrderControllerTests : TestControllerBase
    {
        [Fact]
        public async Task Create_website_order_returns_OK_response()
        {
            using (var server = CreateTestServer())
            {
                // ARRANGE
                var content = new StringContent(TestHelpers.CreateWebsiteOrderModel(), Encoding.UTF8, "application/json");

                // ACT
                var response = await server.CreateClient().PostAsync("api/order", content);

                // ASSERT
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Create_addcampaign_order_returns_OK_response()
        {
            using (var server = CreateTestServer())
            {
                // ARRANGE
                var content = new StringContent(TestHelpers.CreateAdWordCampaingOrderModel(), Encoding.UTF8, "application/json");

                // ACT
                var response = await server.CreateClient().PostAsync("api/order", content);

                // ASSERT
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Create_multiple_products_order_returns_OK_response()
        {
            using (var server = CreateTestServer())
            {
                // ARRANGE
                var content = new StringContent(TestHelpers.CreateMixedOrderModel(), Encoding.UTF8, "application/json");

                // ACT
                var response = await server.CreateClient().PostAsync("api/order", content);

                // ASSERT
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }

        [Fact]
        public async Task Create_order_with_invalid_product_type_returns_bad_request()
        {
            using (var server = CreateTestServer())
            {
                // ARRANGE
                var content = new StringContent(TestHelpers.CreateOrderInvalidProductTypeModel(), Encoding.UTF8, "application/json");

                // ACT
                var response = await server.CreateClient().PostAsync("api/order", content);

                // ASSERT
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async Task Create_order_without_order_id_returns_bad_request()
        {
            using (var server = CreateTestServer())
            {
                // ARRANGE
                var content = new StringContent(TestHelpers.CreateOrderMissingIdModel(), Encoding.UTF8, "application/json");

                // ACT
                var response = await server.CreateClient().PostAsync("api/order", content);

                // ASSERT
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async Task Create_order_without_product_id_returns_bad_request()
        {
            using (var server = CreateTestServer())
            {
                // ARRANGE
                var content = new StringContent(TestHelpers.CreateOrderMissingProductIdModel(), Encoding.UTF8, "application/json");

                // ACT
                var response = await server.CreateClient().PostAsync("api/order", content);

                // ASSERT
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async Task Create_existing_order_returns_bad_request()
        {
            using (var server = CreateTestServer())
            {
                // ARRANGE
                var content = new StringContent(TestHelpers.CreateWebsiteOrderModel(), Encoding.UTF8, "application/json");

                // ACT
                var response = await server.CreateClient().PostAsync("api/order", content);

                // ASSERT
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
