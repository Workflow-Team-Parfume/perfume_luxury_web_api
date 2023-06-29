using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Care>? Cares { get; set; }
        public ICollection<Parfume>? Parfumes { get; set; }
    }
}
