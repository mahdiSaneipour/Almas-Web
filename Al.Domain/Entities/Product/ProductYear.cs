using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Domain.Entities.Product
{
    public class ProductYear
    {
        [Key]
        public int YearId { get; set; }

        [Display(Name = "سال تولید")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public int ProductionYear { get; set; }

        #region Relations

        public ICollection<Product> Products { get; set; }

        #endregion
    }
}
