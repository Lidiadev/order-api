using Order.Domain.Dtos;
using Order.Domain.Models.Product;

namespace Order.Domain.Factories
{
    public class WebsiteProductFactory : IProductFactory
    {
        public Product CreateProduct(LineItemDto lineItemDto)
        {
            return new WebsiteProduct(lineItemDto);
        }
    }
}
