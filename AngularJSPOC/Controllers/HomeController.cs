using AngularJSPOC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AngularJSPOC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // GET: All books
        public JsonResult GetAllBooks()
        {
            using (ApplicationDbContext contextObj = new ApplicationDbContext())
            {
                var bookList = contextObj.Test.ToList();
                return Json(bookList, JsonRequestBehavior.AllowGet);
            }
        }
        //GET: Book by Id
        public JsonResult GetBookById(string id)
        {
            using (ApplicationDbContext contextObj = new ApplicationDbContext())
            {
                var bookId = Convert.ToInt32(id);
                var getBookById = contextObj.Test.Find(bookId);
                return Json(getBookById, JsonRequestBehavior.AllowGet);
            }
        }
        //Update Book
        public string UpdateBook(Test book)
        {
            if (book != null)
            {
                using (ApplicationDbContext contextObj = new ApplicationDbContext())
                {
                    int bookId = Convert.ToInt32(book.Id);
                    Test _book = contextObj.Test.Where(b => b.Id == bookId).FirstOrDefault();
                    _book.Title = book.Title;
                    _book.Author = book.Author;
                    _book.Publisher = book.Publisher;
                    _book.Isbn = book.Isbn;
                    contextObj.SaveChanges();
                    return "Book record updated successfully";
                }
            }
            else
            {
                return "Invalid book record";
            }
        }
        // Add book
        public string AddBook(Test book)
        {
            if (book != null)
            {
                using (ApplicationDbContext contextObj = new ApplicationDbContext())
                {
                    contextObj.Test.Add(book);
                    contextObj.SaveChanges();
                    return "Book record added successfully";
                }
            }
            else
            {
                return "Invalid book record";
            }
        }
        // Delete book
        public string DeleteBook(string bookId)
        {

            if (!String.IsNullOrEmpty(bookId))
            {
                try
                {
                    int _bookId = Int32.Parse(bookId);
                    using (ApplicationDbContext contextObj = new ApplicationDbContext())
                    {
                        var _book = contextObj.Test.Find(_bookId);
                        contextObj.Test.Remove(_book);
                        contextObj.SaveChanges();
                        return "Selected book record deleted sucessfully";
                    }
                }
                catch (Exception)
                {
                    return "Book details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }

        public ActionResult Testshared()
        {
            ViewBag.Message = "Your application description page.";

            //return View("Index");
            return RedirectToAction("Index");
        }

    }
}