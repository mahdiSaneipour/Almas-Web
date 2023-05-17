using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Al.Data;
using System.ComponentModel.DataAnnotations;
using Al.Domain.Entities.User;
using Al.Domain.Entities.Product;
using Al.Domain.Entities.Factors;
using Al.Domain.Entities.Admin;

namespace Al.Data.Context
{
    public class AlContext : IdentityDbContext<ApplicationUser>
    {
        public AlContext(DbContextOptions<AlContext> options) : base(options)
        {
        }

        #region Products

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductColor> Colors { get; set; }

        public DbSet<ProductCountry> Countries { get; set; }

        public DbSet<ProductGroup> Groups { get; set; }

        public DbSet<ProductFactory> Factories { get; set; }

        public DbSet<ProductYear> Years { get; set; }

        public DbSet<ProductImage> PImages { get; set; }

        public DbSet<ProductDiscount> Discounts { get; set; }

        #endregion

        #region Factors

        public DbSet<Factor> Factors { get; set; }

        public DbSet<FactorDetail> FactorDetails { get; set; }

        #endregion

        #region Admin

        public DbSet<SlideBanner> SlideBanners { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
            .HasOne(p => p.Discount)
            .WithOne(p => p.Product)
            .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(builder);
        }
    }
}
