using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadMe.Models;
using ReadMe.ViewModels;

namespace ReadMe.Controllers
{
    public class BooksController : Controller
    {
        
        //GET: /Books/Random
        public ActionResult Random()
        {
            var book = new Book() { Name = "Gra o tron" };
            var users = new List<Customer>
            {
                new Customer { Name = "User1" },
                new Customer { Name = "User2" },
            };

            var viewModel = new RandomBookViewModel
            {
                Book = book,
                Users = users
            };

            return View(viewModel);
        }

        public ActionResult Index()
        {
            var books = new List<Book>
            { 
                new Book { Name = "Gra o tron" },
                new Book { Name = "Grawitacja" },
                new Book { Name = "Dawca" },
            };

            var viewbook = new Book {
                Books = books
            };

            return View(viewbook);

        }
          

        //[Route("books/released/{year}/{month:regex(\\d{2}:range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{
        //    return Content(year + "/" + month);
        //}




    }


}