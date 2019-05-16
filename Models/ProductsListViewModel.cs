using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Buttons.Domain.Entities;
namespace Buttons.WebUI.Models
{
    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
    }
}