using Order.Domain.ValueObjects;
using System.Collections.Generic;

namespace Order.Domain.Models.Product
{
    public abstract class Product
    {
        public string Id { get; set; }
        public ProductType ProductType { get; set; }
        public string Notes { get; set; }
        public string Category { get; set; }

        public virtual ICollection<LineItem> LineItems { get; set; }

        public Product()
        {

        }

        public Product(string id, ProductType productType, string notes, string category)
        {
            Id = id;
            ProductType = productType;
            Notes = notes;
            Category = category;

            LineItems = new List<LineItem>();
        }
    }
}
