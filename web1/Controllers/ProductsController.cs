using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using web1.Models;


public class ProductsController:Controller
{
    [HttpGet]
    public ViewResult GetAllProducts(string sortBy)
    { 
        List<Product> products=new List<Product>();
        SqlConnection connection=new SqlConnection();
        connection.ConnectionString="Server=WIN-I8619RLSHP\\SQLEXPRESS;Database=TSQL2012;Trusted_Connection=True;";
        connection.Open();
        
        SqlCommand command=new SqlCommand();
        
        if(sortBy==null){
            sortBy="ProductName";
        }
        command.CommandType=CommandType.Text;
        command.CommandText=$"SELECT * FROM GetAllProducts order by {sortBy}";
        command.Connection=connection;
        SqlDataReader reader = command.ExecuteReader();
        
        List<Product> productNames=new List<Product>();
        while (reader.Read())
        {
             Product temp=new Product();
             temp.ProductID=int.Parse(reader["productid"].ToString());
             temp.ProductName=reader["productName"].ToString();
             temp.CategoryID=int.Parse(reader["categoryid"].ToString());
             temp.UnitPrice=double.Parse(reader["unitprice"].ToString());
             productNames.Add(temp);
        }

        ViewData["products"]=productNames;
        return View();   
    }

    
   
}