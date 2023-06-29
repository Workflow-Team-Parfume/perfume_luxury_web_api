using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Care>? Cares { get; set; }
        public ICollection<Parfume>? Parfumes { get; set; }
    }
}
