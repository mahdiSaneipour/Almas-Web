using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Al.Web.Pages.Account
{
    public class SentConfirmEmailModel : PageModel
    {
        
        public string Email { get; set; }

        public void OnGet(string email)
        {
            Email = email;
        }
    }
}
