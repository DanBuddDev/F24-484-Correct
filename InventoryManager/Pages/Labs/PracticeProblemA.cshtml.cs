using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace InventoryManager.Pages.Labs
{
    public class PracticeProblemAModel : PageModel
    {
        [BindProperty]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Please enter a valid integer value.")]
        public int FirstNum { get; set; }
        [BindProperty]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Please enter a valid integer value.")]
        public int SecondNum { get; set; }
        public int NumSum { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            NumSum = FirstNum + SecondNum;
        }

    }
}