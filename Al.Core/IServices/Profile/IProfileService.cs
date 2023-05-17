using Al.Core.DTOs.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.IServices.Profile
{
    public interface IProfileService
    {
        public ShowUserInformation GetUserInformationForProfile();

        public void EditUserInformation(ShowUserInformation info);
    }
}
