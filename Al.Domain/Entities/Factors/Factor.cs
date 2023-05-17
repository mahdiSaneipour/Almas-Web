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
    public class Factor
    {
        [Key]
        public int FactorId { get; set; }

        [Display(Name = "تعداد محصول")]
        public int Count { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime CreatDate { get; set; } = DateTime.Now;

        [Display(Name = "پرداخت")]
        public bool IsPay { get; set; } = false;

        [Display(Name = "تحویل")]
        public bool IsDeliver { get; set; } = false;

        [Display(Name = "مجموع")]
        public long Sum { get; set; }


        public string UserId { get; set; }

        #region Relations

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public ICollection<FactorDetail> FactorDetails { get; set; }

        #endregion
    }
}
