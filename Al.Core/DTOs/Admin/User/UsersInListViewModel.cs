using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Al.Core.DTOs.Admin.User
{
    public class UsersInListViewModel
    {
        public int PageId { get; set; }

        public int TotalPage { get; set; }

        public List<ShowUsersInListViewModel> Users { get; set; }
    }
}
