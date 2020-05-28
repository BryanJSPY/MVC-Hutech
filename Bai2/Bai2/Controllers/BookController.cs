using Bai2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bai2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "aaa", "bbb", "/Content/Images/ccc.jpg"));
            books.Add(new Book(2, "aaa1", "bbb1", "/Content/Images/ccc.jpg"));
            books.Add(new Book(3, "aaa2", "bbb2", "/Content/Images/ccc.jpg"));
            return View(books);
        }

        public ActionResult EditBook(int? id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "aaa", "bbb", "/Content/Images/ccc.jpg"));
            books.Add(new Book(2, "aaa1", "bbb1", "/Content/Images/ccc.jpg"));
            books.Add(new Book(3, "aaa2", "bbb2", "/Content/Images/ccc.jpg"));

            Book book = new Book();

            foreach(Book b in books)
            {
                if(b.Id == id)
                {
                    book = b;
                    break;
                }
            }

            if(book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Editbook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int? id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "aaa", "bbb", "/Content/Images/ccc.jpg"));
            books.Add(new Book(2, "aaa1", "bbb1", "/Content/Images/ccc.jpg"));
            books.Add(new Book(3, "aaa2", "bbb2", "/Content/Images/ccc.jpg"));

            if (id == null)
            {
                return HttpNotFound();
            }

            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }


            return View("ListBookModel", books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include ="Id,Title,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "aaa", "bbb", "/Content/Images/ccc.jpg"));
            books.Add(new Book(2, "aaa1", "bbb1", "/Content/Images/ccc.jpg"));
            books.Add(new Book(3, "aaa2", "bbb2", "/Content/Images/ccc.jpg"));

            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }


            return View("ListBookModel", books);
        }

        public ActionResult Details(Book book)
        {
            return View(book);
        }
    }
}