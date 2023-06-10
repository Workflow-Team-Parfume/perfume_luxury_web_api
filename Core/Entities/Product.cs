using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public abstract class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Img_Path { get; set; }
        public int BrandId { get; set; }
        public Brand Brand{ get; set; }
        public bool InStock { get; set; }
        public ICollection<Rating>? Ratings { get; set; }
        public int AmountId { get; set; }
        public Amount Amount { get; set; }
        public ICollection<Order>? Orders { get; set; }

    }
}
