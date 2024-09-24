using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace InventoryManager.Pages.Labs
{
    public class PracticeProblemBModel : PageModel
    {
        [BindProperty]
        [Range(int.MinValue, int.MaxValue,ErrorMessage ="Please enter a valid integer value.")]
        public int FirstNum { get; set; }
        [BindProperty]
        [Range(int.MinValue, int.MaxValue, ErrorMessage = "Please enter a valid integer value.")]
        public int SecondNum { get; set; }
        public int NumOrderer { get; set; }        
        public int[] NumArray { get; set; }

        public void OnGet()
        {
        }
        public void OnPost()
        {            
        }
        public IActionResult OnPostPopulateHandler()
        {
            //Orders the input numbers from smallest to largest
            if(FirstNum >= SecondNum)
            {
                NumOrderer = SecondNum;
                SecondNum = FirstNum;
                FirstNum = NumOrderer;
            }
            //assigns array size to difference between the numbers minus 1 to include size for only values between
            NumArray = new int[(SecondNum-FirstNum)-1];

            //iterates using for loop to assign value; Add 1 to firstnum to begin assigning to the array the number after the first num
            int indexer = 0;
            for (int i = FirstNum+1;i < SecondNum;i++)
            {
                NumArray[indexer] = i;
                indexer++;
            }
            return Page();
        }
    }
}