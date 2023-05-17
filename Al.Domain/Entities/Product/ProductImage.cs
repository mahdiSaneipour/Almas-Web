using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.Entities.Product
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [MaxLength(300, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string ImageAddress { get; set; }

        public int ProductId { get; set; }

        #region Relations

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        #endregion
    }
}
