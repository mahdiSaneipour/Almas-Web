using Al.Domain.Entities.Product;
using Al.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.Entities.Factors
{
    public class FactorDetail
    {
        [Key]
        public int FD_Id { get; set; }

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [MaxLength(150, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string ProductName { get; set; }

        [Display(Name = "تعداد")]
        public int Count { get; set; }

        [Display(Name = "قیمت")]
        public long Price { get; set; }

        public int ProductId { get; set; }

        public int FactorId { get; set; }

        #region Relations

        [ForeignKey(nameof(ProductId))]
        public Product.Product Product { get; set; }

        [ForeignKey(nameof(FactorId))]
        public Factor Factor { get; set; }

        #endregion
    }
}
