using System.Collections.Generic;

namespace Order.Domain.Models
{
    public class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Company(string id, string name)
        {
            Id = id;
            Name = Name;
        }
    }
}
