using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.ChangePassword
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "رمز فعلی")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string OldPassword { get; set; }

        [Display(Name = "رمز جدید")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string NewPassword { get; set; }
    }
}
