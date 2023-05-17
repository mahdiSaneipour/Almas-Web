using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.Product
{
    public class EditProduct
    {
        public int ProductId { get; set; }

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string ProductName { get; set; }

        [Display(Name = "مدل محصول")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string Model { get; set; }

        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public long ProductPrice { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string Description { get; set; }

        public int GroupId { get; set; }

        public int SubGroupId { get; set; }

        public int YearId { get; set; }

        public int FactoryId { get; set; }

        public int CountryId { get; set; }

        public int ColorId { get; set; }

        public string? Images { get; set; } = null;
    }
}
