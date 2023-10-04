using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Parfume
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImgPath { get; set; }
        public int BrandId { get; set; }
        public int AmountId { get; set; }
        public bool InStock { get; set; }
        public decimal Price { get; set; }
        public int? ParfumeLeftMl { get; set; }
        public bool IsBottling { get; set; }
    }
}
