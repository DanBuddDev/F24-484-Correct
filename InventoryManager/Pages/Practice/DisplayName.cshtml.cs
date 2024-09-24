using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Pages.Practice
{
    public class DisplayNameModel : PageModel
    {
        public String TestName { get; set; }
        [BindProperty]
        [Required]
        public String FirstName {  get; set; }
        [BindProperty]
        [Required]
        public String SecondName { get; set; }   


        public void OnGet()
        {
            //onget xxecute when page is rendered and loaded
            TestName = "Dan";
            
        }
        public void OnPost() {
            //onpost exec when post  reec, view page oof this raz page, onpost default post method for
        }

        public IActionResult OnPostPopulateHandler()
        {
            ModelState.Clear();
            SecondName = "TestSecondName";
            FirstName = "TestFirstName";

            return Page();//Sends browser back to the view for this Razor page
        }
    }
}
