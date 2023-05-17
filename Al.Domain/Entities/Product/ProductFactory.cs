using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.Entities.Product
{
    public class ProductFactory
    {
        [Key]
        public int FactoryId { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [MaxLength(100, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string FactoryName { get; set; }

        #region Relations

        public ICollection<Product> Products { get; set; }

        #endregion
    }
}
