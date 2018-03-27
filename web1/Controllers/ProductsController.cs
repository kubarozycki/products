using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using web1.Models;
using web1.Repository;

public class ProductsController:Controller
{
    [HttpGet]
    public ViewResult GetAllProducts(string sortBy,string searchPhrase,int page)
    { 
        ProductsRepository repo1=new ProductsRepository();
        ViewData["currentpage"]=page;
        ViewData["products"]=repo1.GetAllProducts(sortBy,searchPhrase,page);
        ViewData["sortBy"]=sortBy;
        return View();   
    }

    [HttpGet]
    public ViewResult AddProductForm()
    {
        return View();
    }

    [HttpPost]
    public void AddProduct([FromForm] Product p)
    {
        // todo add to database
    }

    


    
   
}