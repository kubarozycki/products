using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using web1.Models;

namespace web1.Repository
{
    public class ProductsRepository
    {

        public List<Product> GetAllProducts(string sortBy,string searchPhrase,int page)
        {
            List<Product> products = new List<Product>();
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=WIN-I8619RLSHP\\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True;";
            connection.Open();

            SqlCommand command = new SqlCommand();

            if (sortBy == null)
            {
                sortBy = "ProductName";
            }
            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT * FROM GetAllProducts where productname like '%{searchPhrase}%' order by {sortBy} offset {page * 10} rows fetch next 10 rows only";
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            List<Product> productNames = new List<Product>();
            while (reader.Read())
            {
                Product temp = new Product();
                temp.ProductID = int.Parse(reader["productid"].ToString());
                temp.ProductName = reader["productName"].ToString();
                temp.CategoryID = int.Parse(reader["categoryid"].ToString());
                temp.UnitPrice = double.Parse(reader["unitprice"].ToString());
                productNames.Add(temp);
            }
            return productNames;
        }

        public void AddProduct(Product p){
            //todo write query to add to database
        }

    }
}