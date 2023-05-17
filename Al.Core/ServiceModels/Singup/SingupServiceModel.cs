using Al.Core.DTOs.Accounts;
using Al.Core.Enums.Account;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.ServiceModels.Singup
{
    public class SingupServiceModel
    {
        public Domain.Entities.User.ApplicationUser User { get; set; }

        public SingupEnum Status { get; set; }
    }
}
