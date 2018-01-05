using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadMe.Models;
using ReadMe.ViewModels;
using System.Data.Entity.Validation;

namespace ReadMe.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {           
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();
            var bookTypes = _context.BookTypes.ToList();

            var viewModel = new BookFormViewModel
            {
                Genres = genres,
                BookTypes = bookTypes
            };

            return View("BookForm", viewModel);
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BookFormViewModel
                {
                    Book = book,
                    Genres = _context.Genres.ToList(),
                    BookTypes = _context.BookTypes.ToList()
                };

                return View("BookForm", viewModel);
            }

            if (book.Id == 0)
                _context.Books.Add(book);
                     
            else
            {            
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);
                bookInDb.Name = book.Name;
                bookInDb.Author = book.Author;
                bookInDb.GenreId = book.GenreId;
                bookInDb.BookTypeId = book.BookTypeId;
                bookInDb.Popularity = book.Popularity;
            }

            _context.SaveChanges(); // this written changes to database

            return RedirectToAction("Index", "Books");
        }

        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id); // get the books with id from the database

            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = _context.Genres.ToList(),
                BookTypes = _context.BookTypes.ToList()
            };
            return View("BookForm", viewModel);
        }

        [HttpPost]
        public ActionResult IncreasePopularity(int id, Book book)
        {
            var bookInDb = _context.Books.Single(b => b.Id == book.Id);
            bookInDb.Popularity++;

            _context.SaveChanges();

            //return View("ShowBooksFromChosenCategory");
            return Content("Sukces");
        }

        // GET: /Users/
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageBooks))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult ShowBooksFromChosenCategory()
        {
            string dataFromNetwork = TempData["Category"].ToString();
            var books = _context.Books
                .Include(c => c.Genre)
                .Where(c => c.BookType.Name.Equals(dataFromNetwork))
                .OrderByDescending(c => c.Popularity)
                .ToList();

            return View(books);
        }

       
        public ActionResult Details(int id)
        {
            var book = _context.Books.Include(b => b.Genre).SingleOrDefault(b => b.Id == id);

            if (book == null)
                return HttpNotFound();

            return View(book);
        }

    }


}