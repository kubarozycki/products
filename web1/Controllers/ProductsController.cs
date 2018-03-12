using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using web1.Models;
using web1.ViewModels;

public class ProductsController:Controller
{
    [HttpGet]
    public ViewResult GetAllProducts([FromQuery]SearchProductsViewModel searchParams)
    { 
        SqlConnection connection=new SqlConnection();
        connection.ConnectionString="Server=WIN-I8619RLSHP\\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True;";
        connection.Open();
        SqlCommand command=new SqlCommand();
        
        command.CommandType=CommandType.Text;
    
        command.CommandText=$"SELECT * FROM GetAllProducts WHERE productname like '%{searchParams.SearchPhrase}%' order by {searchParams.SortBy} {(searchParams.Asc ? "asc":"desc")} offset {searchParams.Page*10} rows fetch next 10 rows only";
        
        command.Connection=connection;
        SqlDataReader reader = command.ExecuteReader();
        searchParams.Products=new List<Product>();

        while (reader.Read())
        {
             Product temp=new Product();
             temp.ProductID=int.Parse(reader["productid"].ToString());
             temp.ProductName=reader["productName"].ToString();
             temp.Discontinued=bool.Parse(reader["discontinued"].ToString());
             
             searchParams.Products.Add(temp);
        }
       
        return View("GetAllProducts",searchParams);
    }

    [HttpGet]
    public ViewResult Create()
    {
        return View();
    }

    [HttpPost]
    public Product AddProduct([FromBody] Product product)
    {
        string query=$"exec nazwaprocedury {product.ProductName},{product.SupplierID} ";
        return product;
    } 
   
}