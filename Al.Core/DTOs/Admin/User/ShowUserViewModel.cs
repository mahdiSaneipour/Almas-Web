using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.User
{
    public class ShowUserViewModel
    {
        [Display(Name = "ایدی کاربر")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string UserId { get; set; }

        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string Email { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string Username { get; set; }

        [Display(Name = "آدرس")]
        public string Address { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string Number { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "فیلد {0} نمیتواند خالی باشد")]
        public string Name { get; set; }

        public bool IsConfirm { get; set; }
    }
}
