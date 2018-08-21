using AutoFixture;
using Order.Domain.Dtos;
using Order.Domain.Factories;
using Order.Domain.ValueObjects;
using Xunit;

namespace Order.UnitTests.Factories
{
    public class WebsiteProductFactoryTests
    {
        [Fact]
        public void Create_product_success()
        {
            // ARRANGE
            IProductFactory subject = new WebsiteProductFactory();
            var lineItem = new Fixture().Create<LineItemDto>();
            lineItem.ProductType = ProductType.Website;

            // ACT
            var result = subject.CreateProduct(lineItem);

            // ASSERT
            Assert.NotNull(result);
        }
    }
}
