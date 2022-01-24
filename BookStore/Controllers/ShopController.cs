using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class ShopController : Controller
    {
        book_storeEntities10 Context = new book_storeEntities10();
        // GET: Shop
        public ActionResult Index()
        {
            var BookData = Context.books.Where(d => d.Stock > 0).ToList();

            return View("Shop", BookData);
        }
        public ActionResult ShopDetails(int? id)
        {
            book b1 = Context.books.Where(d => d.ISBN == id).FirstOrDefault();

            return View("details", b1);
        }
        public ActionResult addToCart(int id, int Count)
        {
            if (Session["CustomerID"] == null)
            {
                Response.Redirect("/LogIn");
            }
            var b1 = Context.books.Where(d => d.ISBN == id).FirstOrDefault();
            //Context.books.Where(d => d.ISBN == id).FirstOrDefault().Stock -= Count; //solve problem temp
            bool ifexist = false;
            foreach (cart item in Context.carts.ToList())
            {
                if (item.ISBN == id)
                {
                    ifexist = true;
                    item.Count_Of_Books += Count;
                    if (item.Count_Of_Books > b1.Stock)
                        return View("details", b1);  //temp solution
                    item.Total_price_cart = item.Count_Of_Books * b1.Price;
                    Context.SaveChanges();
                    break;
                }
            }
            if (!ifexist)
            {
                cart a1 = new cart();
                int cust = (int)Session["CustomerID"];
                var cust1 = Context.customers.Where(x => x.customer_id == cust).FirstOrDefault();
                a1.ISBN = id;
                a1.customer_id = cust1.customer_id;
                a1.Count_Of_Books = Count;
                a1.Total_price_cart = Count * b1.Price;
                Context.carts.Add(a1);
                Context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}