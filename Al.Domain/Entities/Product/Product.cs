using Al.Domain.Entities.Admin;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.Entities.Product
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [MaxLength(150, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string ProductName { get; set; }

        [Display(Name = "مدل")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [MaxLength(150, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Model { get; set; }

        [Display(Name = "قیمت")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public long Price { get; set; } = 0;

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string Description { get; set; }

        [Display(Name = "نمایش در بنر")]
        public bool IsSlide { get; set; }

        public int GroupId { get; set; }

        public int YearId { get; set; }

        public int FactoryId { get; set; }

        public int CountryId { get; set; }

        public int ColorId { get; set; }

        public int? DiscountId { get; set; }

        #region Relations

        [ForeignKey(nameof(GroupId))]
        public ProductGroup Group { get; set; }

        [ForeignKey(nameof(YearId))]
        public ProductYear Year { get; set; }

        [ForeignKey(nameof(FactoryId))]
        public ProductFactory Factory { get; set; }

        [ForeignKey(nameof(CountryId))]
        public ProductCountry Country { get; set; }

        [ForeignKey(nameof(ColorId))]
        public ProductColor Color { get; set; }

        public ICollection<ProductImage> Images { get; set; }

        [ForeignKey(nameof(DiscountId))]
        public ProductDiscount Discount { get; set; }

        #endregion
    }
}
