using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cs43.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cs43.Domain.EntityTypeConfigarations
{
    public class CategoryEntityTypeConfiguration
    {
        public static void Configuration(EntityTypeBuilder<Product> buildAction)
        {
            buildAction.ToTable("product");
            buildAction.HasKey(p => p.Id);
            buildAction.Property(p => p.Id).HasColumnName("id").ValueGeneratedOnAdd();
            buildAction.Property(p => p.Name).HasColumnName("name").IsRequired();
            buildAction.Property(p => p.Price).HasColumnName("price").IsRequired();
            buildAction.Property(p => p.CategoryId).HasColumnName("category_id").IsRequired();
            buildAction.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
