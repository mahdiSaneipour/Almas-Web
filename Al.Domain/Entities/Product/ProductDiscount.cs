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
    public class ProductDiscount
    {
        [Key]
        public int DiscountId { get; set; }

        [Display(Name = "نام تخفیف")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string DiscountName { get; set; }

        [Display(Name = "شروع تخفیف")]
        public DateTime StartDiscount { get; set; }

        [Display(Name = "اتمام تخفیف")]
        public DateTime EndDiscount { get; set; }

        [Display(Name = "درصد تخفیف")]
        public int DiscountPercent { get; set; }

        public int? ProductId { get; set; }

        public bool IsGolden { get; set; }

        #region Relations

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        #endregion
    }
}
