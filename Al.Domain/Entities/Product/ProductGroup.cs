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
    public class ProductGroup
    {
        [Key]
        public int GroupId { get; set; }

        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [MaxLength(50, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string GroupName { get; set; }

        [Display(Name = "زیر مجموعه")]
        public int? ParentId { get; set; }

        #region Relations

        [ForeignKey(nameof(ParentId))]
        public ICollection<ProductGroup> Groups { get; set; }

        [InverseProperty("Groups")]
        public ProductGroup? Parent { get; set; }

        public ICollection<Product> Products { get; set; }

        #endregion
    }
}
