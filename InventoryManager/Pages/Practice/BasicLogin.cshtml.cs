using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InventoryManager.Pages.Practice
{
    public class BasicLoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; }

        public void OnGet(bool nologin)
        {
            if (nologin) 
            {
                Message = "You must first log in to access this system.";
            }
        }
        public IActionResult OnPost() 
        {
            if (Username.Equals("DLBudd") && Password.Equals("12345"))
            {
                return RedirectToPage("Userlanding", new { username = Username, loginsuccess = true });
            }
            else
            {
                Message = "Incorrect Username / Password. Please try again!";
                return Page();
            }

        }
    }
}
