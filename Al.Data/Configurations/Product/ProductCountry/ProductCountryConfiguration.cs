using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Data.Configurations.Product.ProductCountry
{
    internal class ProductCountryConfiguration : IEntityTypeConfiguration<Domain.Entities.Product.ProductCountry>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Product.ProductCountry> builder)
        {
            builder.HasData(new Domain.Entities.Product.ProductCountry()
            {
                CountryId = 1,
                CountryName = "Iran"
            },
            new Domain.Entities.Product.ProductCountry()
            {
                CountryId = 2,
                CountryName = "Israel"
            },
            new Domain.Entities.Product.ProductCountry()
            {
                CountryId = 3,
                CountryName = "China"
            },
            new Domain.Entities.Product.ProductCountry()
            {
                CountryId = 4,
                CountryName = "USA"
            });
        }
    }
}
