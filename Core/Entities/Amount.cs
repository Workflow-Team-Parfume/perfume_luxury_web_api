using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Amount
    {
        public int Id { get; set; }
        public int Mililitters { get; set; }
        public ICollection<Care>? Cares { get; set; }
        public ICollection<Parfume>? Parfumes { get; set; }
    }
}
