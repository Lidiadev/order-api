using Order.Domain.Dtos;
using Order.Domain.Models.Product;

namespace Order.Domain.Factories
{
    public class PaidSearchProductFactory : IProductFactory
    {
        public Product CreateProduct(LineItemDto lineItemDto)
        {
            return new PaidSearchProduct(lineItemDto);
        }
    }
}
