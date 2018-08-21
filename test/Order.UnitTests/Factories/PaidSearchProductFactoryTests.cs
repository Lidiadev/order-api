using AutoFixture;
using Order.Domain.Dtos;
using Order.Domain.Factories;
using Order.Domain.ValueObjects;
using Xunit;

namespace Order.UnitTests.Factories
{
    public class PaidSearchProductFactoryTests
    {
        [Fact]
        public void Create_product_success()
        {
            // ARRANGE
            IProductFactory subject = new PaidSearchProductFactory();
            var lineItem = new Fixture().Create<LineItemDto>();
            lineItem.ProductType = ProductType.PaidSearch;

            // ACT
            var result = subject.CreateProduct(lineItem);

            // ASSERT
            Assert.NotNull(result);
        }
    }
}
