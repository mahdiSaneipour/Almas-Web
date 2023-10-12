using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Configurations.Product.ProductColor
{
    internal class ProductColorConfiguration : IEntityTypeConfiguration<Domain.Entities.Product.ProductColor>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Product.ProductColor> builder)
        {
            builder.HasData(new Domain.Entities.Product.ProductColor()
            {
                ColorId = 1,
                ColorName = "قرمز",
            },
            new Domain.Entities.Product.ProductColor()
            {
                ColorId = 2,
                ColorName = "آبی",
            },
            new Domain.Entities.Product.ProductColor()
            {
                ColorId = 3,
                ColorName = "مشکی",
            },
            new Domain.Entities.Product.ProductColor()
            {
                ColorId = 4,
                ColorName = "بنفش",
            });
        }
    }
}
