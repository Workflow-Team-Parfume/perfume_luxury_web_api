using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Parfume : Product
    {
        public decimal Price { get; set; }
        public int ParfumeLeftMl { get; set; }
        public bool IsBottling { get; set; }
    }
}
