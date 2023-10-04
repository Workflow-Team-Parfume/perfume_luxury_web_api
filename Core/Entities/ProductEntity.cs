using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;

public class ProductEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string? Description { get; set; }

    public int? ParfumeLeftMl { get; set; }

    public int InStock { get; set; }

    public string ImgPath { get; set; }

    public decimal Price { get; set; }

    public int BrandId { get; set; }

    public Brand Brand { get; set; }

    public ICollection<Rating>? Ratings { get; set; }

    public int AmountId { get; set; }

    public Amount? Amount { get; set; }

    public ICollection<Order>? Orders { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }


}
