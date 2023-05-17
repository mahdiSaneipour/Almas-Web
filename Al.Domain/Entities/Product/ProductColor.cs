using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.Entities.Product
{
    public class ProductColor
    {
        [Key]
        public int ColorId { get; set; }

        [Display(Name = "نام رنگ")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string ColorName { get; set; }

        #region Relations

        public ICollection<Product> Products { get; set; }

        #endregion
    }
}
