using Microsoft.AspNetCore.Mvc;
using Moq;
using Order.Api.Controllers;
using Order.Api.Models.Order;
using Order.Api.Services.Interfaces;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Order.UnitTests.Controllers
{
    public class OrderControllerTests
    {
        private readonly Mock<IOrderService> _orderService;
        private readonly OrderController _subject;

        public OrderControllerTests()
        {
            _orderService = new Mock<IOrderService>();

            _subject = new OrderController(_orderService.Object);
        }

        [Fact]
        public async Task Post_CreateOrder_Success()
        {
            // ARRANGE 
            var orderModel = new OrderModel();
            _orderService.Setup(x => x.SaveAsync(orderModel)).Returns(Task.FromResult(true));

            // ACT 
            var result = await _subject.Post(orderModel) as OkResult;

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task Post_CreateOrder_BadRequest()
        {
            // ARRANGE 
            var orderModel = new OrderModel();
            _orderService.Setup(x => x.SaveAsync(orderModel)).Returns(Task.FromResult(false));

            // ACT 
            var result = await _subject.Post(orderModel) as BadRequestResult;

            // ASSERT
            Assert.NotNull(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
