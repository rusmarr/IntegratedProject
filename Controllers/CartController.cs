using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Buttons.Domain.Abstract;
using Buttons.Domain.Entities;
using Buttons.WebUI.Models;

namespace Buttons.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repository;

        public CartController(IProductRepository repo)
        {
            repository = repo;
        }
        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if(cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public RedirectToRouteResult AddToCart(Cart cart, int ProductID, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == ProductID);
            if(product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int ProductID, string returnUrl)
        {
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == ProductID);
            if(product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        // GET: Cart
        public ActionResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                
                ReturnUrl = returnUrl,
                Cart = cart

            });
           
        }
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}