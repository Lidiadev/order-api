using Order.Api.Infrastructure.Exceptions;
using Order.Api.Services.Interfaces;
using Order.Domain.Dtos;
using Order.Domain.Factories;
using Order.Domain.Models.Product;
using Order.Domain.ValueObjects;

namespace Order.Api.Services
{
    public class ProductManager : IProductManager
    {
        private IProductFactory _productFactory;

        public Product OrderProduct(LineItemDto lineItemDto)
        {
            switch (lineItemDto.ProductType)
            {
                case ProductType.Website:
                    _productFactory = new WebsiteProductFactory();
                    break;
                case ProductType.PaidSearch:
                    _productFactory = new PaidSearchProductFactory();
                    break;
                default:
                    throw new OrderException($"Product type {lineItemDto.ProductType} is not valid.");
            }

            return _productFactory.CreateProduct(lineItemDto);
        }
    }
}
