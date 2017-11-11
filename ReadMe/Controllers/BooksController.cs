using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadMe.Models;
using ReadMe.ViewModels;

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

        // GET: /Users/
        public ActionResult Index()
        {
            var books = _context.Books.ToList();

            return View(books);
        }

    }


}