using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryManager.Pages.Practice
{
    public class UserLandingModel : PageModel
    {
        public String Message { get; set; }

        public IActionResult OnGet(String username, bool loginsuccess)
        {
            if (username != null)
            {
                if(loginsuccess)
                {
                    Message = "User " + username + " successfully logged in!";
                    return Page();
                }
            }
            else
            {
                return RedirectToPage("BasicLogin",new {nologin = true});
            }
            return Page();
            

        }
    }
}
