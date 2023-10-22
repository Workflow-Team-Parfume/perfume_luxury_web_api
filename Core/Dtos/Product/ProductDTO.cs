using Core.Dtos.Brand;
using Core.Dtos.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Parfume
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImgPath { get; set; }
        public bool Active { get; set; }
        public BrandDTO Brand { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
