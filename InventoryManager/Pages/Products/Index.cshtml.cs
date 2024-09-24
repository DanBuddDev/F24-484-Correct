using InventoryManager.Pages.DataClasses;
using InventoryManager.Pages.DB;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace InventoryManager.Pages.Products
{
    public class IndexModel : PageModel
    {
        public List<Product> ProductInventory { get; set; }

        public IndexModel()
        {
            ProductInventory = new List<Product>(); 
        }

        public void OnGet() {
            
            SqlDataReader productReader = DBClass.ProductReader();
            while (productReader.Read())
            {
                ProductInventory.Add(new Product
                {
                    ProductID = Int32.Parse(productReader["ProductID"].ToString()),
                    ProductName = productReader["ProductName"].ToString(), 
                    ProductCost = Double.Parse(productReader["ProductCost"].ToString()),
                    ProductDescription = productReader["ProductDescription"].ToString()
                }) ;
            }

            // Close your connection in DBClass
            DBClass.GroceryDBConnection.Close();
        
        }
    }
}
