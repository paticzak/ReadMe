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

        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new NewBookViewModel
            {
                Genres = genres
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Save(Book book)
        {
            if (book.Id == 0)
                _context.Books.Add(book);
            else
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);
                bookInDb.Name = book.Name;
                bookInDb.Author = book.Author;
                bookInDb.Genre = book.Genre;
            }

            _context.SaveChanges();       

            return RedirectToAction("Index", "Books");
        }

        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id); // get the books with id from the database

            if (book == null)
                return HttpNotFound();

            var viewModel = new NewBookViewModel
            {
                Book = book,
                Genres = _context.Genres.ToList()
            };
            return View("New", viewModel);
        }

        // GET: /Users/
        public ActionResult Index()
        {
            var books = _context.Books.Include(b => b.Genre).ToList();

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