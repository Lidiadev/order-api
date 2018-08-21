using Moq;
using Order.Api.Infrastructure.Exceptions;
using Order.Api.Models.Order;
using Order.Api.Services;
using Order.Api.Services.Interfaces;
using Order.Domain.Dtos;
using Order.Domain.Interfaces;
using Order.Domain.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Order.UnitTests.Services
{
    public class OrderServiceTests
    {
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<IProductManager> _productManager;
        private readonly IOrderService _subject;

        public OrderServiceTests()
        {
            _productRepository = new Mock<IProductRepository>();
            _orderRepository = new Mock<IOrderRepository>();
            _productManager = new Mock<IProductManager>();

            _subject = new OrderService(_orderRepository.Object, _productRepository.Object, _productManager.Object);
        }

        [Fact]
        public async Task Save_new_order_success()
        {
            // ARRANGE
            var order = CreateFakeOrder();
            _orderRepository.Setup(x => x.Insert(It.IsAny<Domain.Models.Order>()))
                .Returns(Task.FromResult(true));
            _productRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
               .Returns(Task.FromResult((Product)new WebsiteProduct()));
            _productManager.Setup(x => x.OrderProduct(It.IsAny<LineItemDto>()))
                .Returns(new WebsiteProduct());

            // ACT
            var result = await _subject.SaveAsync(order);

            // ASSERT
            Assert.True(result);
        }

        [Fact]
        public async Task Save_new_order_failure()
        {
            // ARRANGE
            var order = CreateFakeOrder();
            _orderRepository.Setup(x => x.Insert(It.IsAny<Domain.Models.Order>()))
                .Returns(Task.FromResult(false));
            _productRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
               .Returns(Task.FromResult((Product)new WebsiteProduct()));
            _productManager.Setup(x => x.OrderProduct(It.IsAny<LineItemDto>()))
                .Returns(new WebsiteProduct());

            // ACT
            var result = await _subject.SaveAsync(order);

            // ASSERT
            Assert.False(result);
        }

        [Fact]
        public async Task Save_existing_order_throws_exception()
        {
            // ARRANGE
            var order = CreateFakeOrder();
            _orderRepository.Setup(x => x.GetByIdAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new Domain.Models.Order()));
            _productManager.Setup(x => x.OrderProduct(It.IsAny<LineItemDto>()))
                .Returns(new WebsiteProduct());

            // ACT
            await Assert.ThrowsAsync<OrderException>(() => _subject.SaveAsync(order));
        }

        private OrderModel CreateFakeOrder()
        => new OrderModel
        {
            CompanyID = "12345",
            CompanyName = "CompanyName",
            OrderID = "1",
            Partner = "Partner",
            SubmittedBy = "PartnerX",
            TypeOfOrder = "Regular",
            LineItems = new List<LineItemModel>
            {
                new LineItemModel
                {
                    ProductID = "1001",
                    ProductType = "Website",
                    Category = "Regular",
                    WebsiteDetails = new WebsiteDetailsModel
                    {
                        TemplateId = "10001"
                    }
                }
            }
        };
    }
}
