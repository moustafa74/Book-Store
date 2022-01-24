using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class CheckOutController : Controller
    {
        // GET: CheckOut
        book_storeEntities10 Context = new book_storeEntities10();
        public ActionResult Index()
        {
            int customer_id = (int)Session["CustomerID"];
            var add1 = Context.carts.Where(d => d.customer_id == customer_id).ToList();
            if (add1.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }
            return View(add1);
        }
        public ActionResult Confirmation(bool? isorederd)
        {
            Nullable<float> total = 0;
            int customer_id = (int)Session["CustomerID"];
            var add1 = Context.carts.Where(d => d.customer_id == customer_id).ToList();
            order order1 = new order();
            Context.orders.Add(order1);
            foreach (cart item in add1)
            {
                sub_order suboredr1 = new sub_order();
                suboredr1.Order_id =order1.Order_id;
                suboredr1.ISBN = item.ISBN;
                suboredr1.Total_price_sub = item.Total_price_cart;
                suboredr1.count = item.Count_Of_Books;
                Context.books.Where(d => d.ISBN == item.ISBN).FirstOrDefault().Stock -= item.Count_Of_Books;
                Context.carts.Remove(item);
                Context.sub_order.Add(suboredr1);
                total += suboredr1.Total_price_sub; //precudre or trigger

            }
            order1.customer_id = customer_id;
            order1.Date = System.DateTime.Today;
            order1.Total = total;
            if (order1.Total == 0)            //refresh conformation page problem
            {
                Response.Redirect("/Home");
                Context.orders.Remove(order1);
            }
            Context.SaveChanges();
            return View(order1);
        }
    }
}