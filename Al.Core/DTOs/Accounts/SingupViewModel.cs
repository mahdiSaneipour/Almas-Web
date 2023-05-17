using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Accounts
{
    public class SingupViewModel
    {
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "ایمیل معتبر وارد کنید")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        [DataType(DataType.EmailAddress, ErrorMessage = "فرمت ایمیل معتبر نمیباشد")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string Username { get; set; }

        [Display(Name = "شماره تلفن")]
        [DataType(DataType.PhoneNumber)]
        public string? Number { get; set; }

        [Display(Name = "اسم و فامیل")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string Name { get; set; }

        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string Password { get; set; }

        [Display(Name = "تکرار رمز عبور")]
        [Compare(nameof(Password), ErrorMessage = "رمز و تکرار رمز با هم یکسان نیستند")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string ConfirmPassword { get; set; }
    }
}
