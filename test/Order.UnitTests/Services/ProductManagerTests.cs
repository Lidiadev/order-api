using AutoFixture;
using Order.Api.Infrastructure.Exceptions;
using Order.Api.Services;
using Order.Api.Services.Interfaces;
using Order.Domain.Dtos;
using Order.Domain.Models.Product;
using Order.Domain.ValueObjects;
using Xunit;

namespace Order.UnitTests.Services
{
    public class ProductManagerTests
    {
        private readonly IProductManager _subject;

        public ProductManagerTests()
        {
            _subject = new ProductManager();
        }

        [Fact]
        public void Order_new_website_product_success()
        {
            // ARRANGE
            var lineItem = new Fixture().Create<LineItemDto>();
            lineItem.ProductType = ProductType.Website;
            // ACT
            var result = _subject.OrderProduct(lineItem);

            // ASSERT
            Assert.NotNull(result);
            Assert.IsType<WebsiteProduct>(result);
        }

        [Fact]
        public void Order_new_paidsearch_product_success()
        {
            // ARRANGE
            var lineItem = new Fixture().Create<LineItemDto>();
            lineItem.ProductType = ProductType.PaidSearch;
            // ACT
            var result = _subject.OrderProduct(lineItem);

            // ASSERT
            Assert.NotNull(result);
            Assert.IsType<PaidSearchProduct>(result);
        }

        [Fact]
        public void Order_new_invalid_product_type_throws_exception()
        {
            // ARRANGE
            var lineItem = new Fixture().Create<LineItemDto>();
            lineItem.ProductType = (ProductType)(-1);

            // ACT
            // ASSERT
            Assert.Throws<OrderException>(() => _subject.OrderProduct(lineItem));
        }
    }
}
