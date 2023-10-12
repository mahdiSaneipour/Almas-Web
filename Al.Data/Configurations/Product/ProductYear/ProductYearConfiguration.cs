using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Configurations.Product.ProductYear
{
    internal class ProductYearConfiguration : IEntityTypeConfiguration<Domain.Entities.Product.ProductYear>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Product.ProductYear> builder)
        {
            builder.HasData(new Domain.Entities.Product.ProductYear()
            {
                YearId = 1,
                ProductionYear = 2019
            },
            new Domain.Entities.Product.ProductYear()
            {
                YearId = 2,
                ProductionYear = 2020
            },
            new Domain.Entities.Product.ProductYear()
            {
                YearId = 3,
                ProductionYear = 2021
            },
            new Domain.Entities.Product.ProductYear()
            {
                YearId = 4,
                ProductionYear = 2022
            },
            new Domain.Entities.Product.ProductYear()
            {
                YearId = 5,
                ProductionYear = 2023
            },
            new Domain.Entities.Product.ProductYear()
            {
                YearId = 6,
                ProductionYear = 2024
            });
        }
    }
}
