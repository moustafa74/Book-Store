    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
namespace BookStore.Controllers
{
    public class SearchResultController : Controller
    {
        // GET: SearchResult
        book_storeEntities10 context = new book_storeEntities10();
        public ActionResult Index(string searchName)
        {
            var book1 = context.books.Where(c => c.Title.Contains(searchName)&&c.Stock>0).ToList();
            return View(book1);
        }
    }
}