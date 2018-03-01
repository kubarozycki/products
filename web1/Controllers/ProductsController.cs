using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class ProductsController:Controller
{
    public List< Product> GetAllProducts(string searchedPhrase)
    {
        SqlConnection connection=new SqlConnection();
        connection.ConnectionString="Server=WIN-I8619RLSHP\\SQLEXPRdESS;Database=TSQL2012;Trusted_Connection=True;";
        connection.Open();
        SqlCommand command=new SqlCommand();
        
        command.CommandType=CommandType.Text;
        command.CommandText=$"SELECT * FROM GetAllProducts WHERE productname like '%{searchedPhrase}%'";
        command.Connection=connection;
        SqlDataReader reader = command.ExecuteReader();
        
        List<Product> productNames=new List<Product>();
        while (reader.Read())
        {
             Product temp=new Product();
             temp.ProductID=int.Parse(reader["productid"].ToString());
             temp.ProductName=reader["productName"].ToString();
             
             productNames.Add(temp);
        }
        
        return productNames;
    }
}