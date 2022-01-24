using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class DashboardController : Controller
    {
        book_storeEntities10 Context = new book_storeEntities10();
        // GET: Dashboard
        public ActionResult Index()
        {
            if (Session["AdminID"] == null)
            {
                Response.Redirect("/AdminLogin");
            }
            return View(Context.books.ToList());
        }
        public ActionResult Open_Add_book()
        {
            return View();
        }
        public ActionResult Save_Add_book(BookModel book1)
        {
            var cheakforisbn = Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault();//cheak if isbn exist
            if(cheakforisbn!=null)
            {
                ViewData["eror"] = "This ISBN is Exists";
                ViewData["errorbook"] = book1.ISBN;
                return View("Open_Add_book");
            }
            book b1 = new book();
            var fileExtenstion = Path.GetExtension(book1.Image_file.FileName);
            var imageguid = Guid.NewGuid().ToString();
            b1.Image = imageguid + fileExtenstion;
            string filePath = Server.MapPath($"~/content/assets/img/Books/{b1.Image}");
            book1.Image_file.SaveAs(filePath);
            b1.ISBN = book1.ISBN;
            b1.Title = book1.Title;
            b1.Stock = book1.Stock;
            var cheakfor_Pid = Context.publishers.Where(d => d.Publisher_id == book1.Publisher_id).FirstOrDefault();//cheak if publisher id exist
            if (cheakfor_Pid == null)
            {
                ViewData["erorPid"] = "This publisher id is not Exists";
                ViewData["errorbook"] = book1.ISBN;
                ViewData["errorPid"] = book1.Publisher_id;
                ViewData["errorAid"] = book1.Author_id;
                return View("Open_Add_book");
            }
            b1.Publisher_id = book1.Publisher_id;
            var cheakfor_Aid = Context.authors.Where(d => d.Author_id == book1.Author_id).FirstOrDefault();//cheak if Author id exist
            if (cheakfor_Aid == null)
            {
                ViewData["erorAid"] = "This Author id is not Exists";
                ViewData["errorPid"] = book1.Publisher_id;
                ViewData["errorbook"] = book1.ISBN;
                ViewData["errorAid"] = book1.Author_id;
                return View("Open_Add_book");
            }
            b1.Author_id= book1.Publisher_id;
            b1.Version = book1.Version;
            b1.Language = book1.Language;
            b1.conclution = book1.Conclution;
            b1.Year = book1.Year;
            b1.Price = book1.Price;
            Context.books.Add(b1);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete_book(int? id)
        {
            book b1 = Context.books.Where(d => d.ISBN == id).FirstOrDefault();           
                Context.books.Remove(b1);
                Context.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Update_book(int? id)
        {
            var b2 = Context.books.Where(d => d.ISBN == id).FirstOrDefault();
            return View(b2);
        }

        public ActionResult Save_update_book(BookModel book1)
        {
            var fileExtenstion = Path.GetExtension(book1.Image_file.FileName);
            var imageguid = Guid.NewGuid().ToString();     
            if (Context.books.Where(d => d.Image == fileExtenstion + imageguid).FirstOrDefault() == null) //fix meomry problem 
            {
                Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().Image = imageguid + fileExtenstion;
                string filePath = Server.MapPath($"~/content/assets/img/Books/{Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().Image}");
                book1.Image_file.SaveAs(filePath);
            }

            Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().Title = book1.Title;
            Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().Stock = book1.Stock;
            var cheakfor_Aid = Context.authors.Where(d => d.Author_id == book1.Author_id).FirstOrDefault();//cheak if Author id exist
            if (cheakfor_Aid == null)
            {
                ViewData["erorAid"] = "This Author id is not Exists";
                Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().Author_id = book1.Author_id;
                return View("Update_book", Context.books.Where(d=>d.ISBN==book1.ISBN).FirstOrDefault());
            }
            Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().Author_id = book1.Author_id;
            var cheakfor_Pid = Context.publishers.Where(d => d.Publisher_id == book1.Publisher_id).FirstOrDefault();//cheak if publisher id exist
            if (cheakfor_Pid == null)
            {
                ViewData["erorPid"] = "This publisher id is not Exists";
                Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().Publisher_id = book1.Publisher_id;
                return View("Update_book", Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault());
            }
            Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().Publisher_id = book1.Publisher_id;
            Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().Version = book1.Version;
            Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().Language = book1.Language;
            Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().conclution = book1.Conclution;
            Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().Year = book1.Year;
            Context.books.Where(d => d.ISBN == book1.ISBN).FirstOrDefault().Price = book1.Price;
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        }
}