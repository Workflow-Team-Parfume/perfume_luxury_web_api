using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Configurations;

public class ProductConfigurations : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder
            .HasMany(p => p.Orders)
            .WithMany(o => o.Products);
        builder
            .HasMany(p => p.Ratings)
            .WithOne(rat => rat.Product)
            .HasForeignKey(a => a.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        builder
            .HasOne(p => p.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.BrandId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        builder
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull);
        builder
            .HasOne(p => p.Amount)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.AmountId)
            .OnDelete(DeleteBehavior.ClientSetNull);
    }
}
