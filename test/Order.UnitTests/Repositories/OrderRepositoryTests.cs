using Moq;
using Order.Domain.Interfaces;
using Order.Infrastructure;
using Order.Infrastructure.Repositories;
using System.Threading.Tasks;
using Xunit;

namespace Order.UnitTests.Repositories
{
    public class OrderRepositoryTests
    {
        private readonly Mock<OrderContext> _context;
        private readonly IOrderRepository _subject;

        public OrderRepositoryTests()
        {
            _context = new Mock<OrderContext>();
            _subject = new OrderRepository(_context.Object);
        }

        [Fact]
        public async Task Order_create_success()
        {
            // ARRANGE
            _context.Setup(x => x.SaveChangesAsync(It.IsAny<System.Threading.CancellationToken>())).Returns(Task.FromResult(1));

            // ACT
            var result = await _subject.Insert(new Domain.Models.Order());

            // ASSERT
            Assert.True(result);
        }

        [Fact]
        public async Task Order_create_failure()
        {
            // ARRANGE
            _context.Setup(x => x.SaveChangesAsync(It.IsAny<System.Threading.CancellationToken>())).Returns(Task.FromResult(-1));

            // ACT
            var result = await _subject.Insert(new Domain.Models.Order());

            // ASSERT
            Assert.False(result);
        }
    }
}
