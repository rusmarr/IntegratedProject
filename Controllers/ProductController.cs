using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buttons.Domain.Abstract;
using Buttons.WebUI.Models;
using Buttons.Domain.Entities;

namespace Buttons.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository myrepository;
        // GET: Product

        public ProductController(IProductRepository productRepository)
        {
            this.myrepository = productRepository;
        }
        public ViewResult Index()
        {
            //return View(myrepository.Products);
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = myrepository.Products
            };
            return View(model);
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public FileContentResult GetImage (int ProductID)
        {
            Product prod = myrepository.Products.FirstOrDefault(p => p.ProductID == ProductID);

            if(prod != null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
    }
}