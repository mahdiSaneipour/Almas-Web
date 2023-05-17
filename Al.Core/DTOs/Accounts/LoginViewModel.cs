using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Accounts
{
    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر وارد کنید")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [DataType(DataType.EmailAddress, ErrorMessage = "فرمت ایمیل معتبر نمیباشد")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string Password { get; set; }
    }
}
