using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using web1.Models;

namespace web1.Controllers
{
    public class CategoryController:Controller
    {
        public List<Category> GetAllCategories()
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=WIN-I8619RLSHP\\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True;";
            connection.Open();
            SqlCommand command = new SqlCommand();

            command.CommandType = CommandType.Text;
            command.CommandText = $"SELECT * FROM Production.Categories";
            command.Connection = connection;
            SqlDataReader reader = command.ExecuteReader();

            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                Category temp = new Category();
                temp.Id = int.Parse(reader["categoryid"].ToString());
                temp.CategoryName = reader["categoryname"].ToString();

                categories.Add(temp);
            }

            return categories;
        }
    }
}