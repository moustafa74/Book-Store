using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        book_storeEntities10 Context = new book_storeEntities10();
        public ActionResult Index()
        {
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("/LogIn");
            }
            int customer_id = (int)Session["CustomerID"];

            var add1 = Context.carts.Where(d => d.customer_id == customer_id).ToList();

            return View(add1);
        }
        public ActionResult RemoveItem(int id)
        {
            cart add1=new cart();
            int customer_id = (int)Session["CustomerID"];
            List<cart> lstfromcart = Context.carts.Where(d => d.customer_id == customer_id).ToList();
            foreach (cart item in lstfromcart)
            {
                if (item.ISBN == id)
                {
                    add1 = item;
                }
            }
            Context.carts.Remove(add1);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}