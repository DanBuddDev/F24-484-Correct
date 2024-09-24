using InventoryManager.Pages.DataClasses;
using System.Data.SqlClient;

namespace InventoryManager.Pages.DB
{
    public class DBClass
    {
        // Use this class to define methods that make connecting to
        // and retrieving data from the DB easier.

        // Connection Object at Data Field Level
        public static SqlConnection GroceryDBConnection = new SqlConnection();

        // Connection String - How to find and connect to DB
        private static readonly String? GroceryDBConnString = 
            "Server=Localhost;Database=Grocery;Trusted_Connection=True";

        //Connection Methods:

        //Basic Product Reader
        public static SqlDataReader ProductReader()
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = GroceryDBConnection;
            cmdProductRead.Connection.ConnectionString = GroceryDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM Product";
            cmdProductRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            //.ExecuteReader() - SELECT
            //.ExecuteNonQuery() - Update, Delete, Insert
            //.ExecuteScalar() - SQL Function: AVG, SUM, COUNT()

            return tempReader;
        }

        // Reads a single Product record from the DB.
        public static SqlDataReader SingleProductReader(int ProductID)
        {
            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = GroceryDBConnection;
            cmdProductRead.Connection.ConnectionString = GroceryDBConnString;
            cmdProductRead.CommandText = "SELECT * FROM Product WHERE ProductID = " + ProductID;
            cmdProductRead.Connection.Open(); // Open connection here, close in Model!

            SqlDataReader tempReader = cmdProductRead.ExecuteReader();

            return tempReader;
        }

        // Inserts one new Product record into the DB.
        public static void InsertProduct(Product p)
        {
            String sqlQuery = "INSERT INTO Product (ProductName,ProductCost,ProductDescription) VALUES ('";
            sqlQuery += p.ProductName + "',";
            sqlQuery += p.ProductCost + ",'";
            sqlQuery += p.ProductDescription + "')";

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = GroceryDBConnection;
            cmdProductRead.Connection.ConnectionString = GroceryDBConnString;
            cmdProductRead.CommandText = sqlQuery;
            cmdProductRead.Connection.Open(); // Open connection here, close in Model!

            cmdProductRead.ExecuteNonQuery();

        }

        // Inserts one new Product record into the DB.
        public static void UpdateProduct(Product p)
        {
            String sqlQuery = "UPDATE Product SET ";
            sqlQuery += "ProductName = '" + p.ProductName + "',";
            sqlQuery += "ProductCost = " + p.ProductCost + ",";
            sqlQuery += "ProductDescription = '" + p.ProductName
                + "' WHERE ProductID = " + p.ProductID;

            SqlCommand cmdProductRead = new SqlCommand();
            cmdProductRead.Connection = GroceryDBConnection;
            cmdProductRead.Connection.ConnectionString = GroceryDBConnString;
            cmdProductRead.CommandText = sqlQuery;
            cmdProductRead.Connection.Open(); // Open connection here, close in Model!

            cmdProductRead.ExecuteNonQuery();

        }
    }
}
