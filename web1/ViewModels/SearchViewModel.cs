using System.Collections.Generic;
using web1.Models;
namespace web1.ViewModels
{
    public class SearchProductsViewModel
    {
        public List<Product> Products {get;set;}
        public string SearchPhrase{get;set;}
        public int Page{get;set;}
        public int SortBy{get;set;}=1;
        public bool Asc{get;set;}=true;
    }
}