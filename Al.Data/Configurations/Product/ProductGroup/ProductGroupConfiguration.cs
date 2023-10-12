using Al.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Configurations.Product.ProductGroup
{
    internal class ProductGroupConfiguration : IEntityTypeConfiguration<Domain.Entities.Product.ProductGroup>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Product.ProductGroup> builder)
        {
            builder.HasData(new Domain.Entities.Product.ProductGroup {
                GroupId = 1,
                GroupName = "محصولات",
                ParentId = null,
            }, new Domain.Entities.Product.ProductGroup
            {
                GroupId = 2,
                GroupName = "لوازم یدکی",
                ParentId = null,
            }, new Domain.Entities.Product.ProductGroup
            {
                GroupId = 3,
                GroupName = "لوازم دسته دوم",
                ParentId = null,
            }, new Domain.Entities.Product.ProductGroup
            {
                GroupId = 4,
                GroupName = "آره برقی",
                ParentId = 1,
            }, new Domain.Entities.Product.ProductGroup
            {
                GroupId = 5,
                GroupName = "ماشین چمن زن",
                ParentId = 2,
            }, new Domain.Entities.Product.ProductGroup
            {
                GroupId = 6,
                GroupName = "پمپ آب",
                ParentId = 3,
            }
            );
        }
    }
}
