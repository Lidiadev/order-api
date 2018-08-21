using AutoMapper;
using Order.Api.Extensions;
using Order.Api.Infrastructure.Exceptions;
using Order.Api.Models.Order;
using Order.Api.Services.Interfaces;
using Order.Domain.Interfaces;
using Order.Domain.Models;
using System.Threading.Tasks;

namespace Order.Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductManager _productManager;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, IProductManager productManager)
        {
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _productManager = productManager;
        }

        public async Task<bool> SaveAsync(OrderModel orderModel)
        {
            var order = await _orderRepository.GetByIdAsync(orderModel.OrderID);

            if (order != null)
                throw new OrderException($"Order with this id {orderModel.OrderID} already exists.");

            var company = new Company(orderModel.CompanyID, orderModel.CompanyName);
            var newOrder = new Domain.Models.Order(orderModel.OrderID, orderModel.TypeOfOrder, orderModel.SubmittedBy, orderModel.Partner, company);

            foreach (var item in orderModel.LineItems)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductID);

                if (product != null)
                    newOrder.AddExistingItem(product);
                else
                {
                    var newProduct = _productManager.OrderProduct(item.ToLineItemsDTO());
                    newOrder.AddItem(newProduct);
                }
            }

            return await _orderRepository.Insert(newOrder);
        }
    }
}
