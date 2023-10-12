using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Configurations.Product.ProductFactory
{
    internal class ProductFactoryConfiguration : IEntityTypeConfiguration<Domain.Entities.Product.ProductFactory>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Product.ProductFactory> builder)
        {
            builder.HasData(new Domain.Entities.Product.ProductFactory()
            {
                FactoryId = 1,
                FactoryName = "ChiTX",
            },
            new Domain.Entities.Product.ProductFactory()
            {
                FactoryId = 2,
                FactoryName = "SinaX",
            });
        }
    }
}
