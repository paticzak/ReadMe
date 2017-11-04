using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadMe.Models;

namespace ReadMe.Controllers
{
    public class UsersController : Controller
    {

        // GET: /Users/
        public ActionResult Index()
        {
            var users =  new List<User> 
            {
                new User { Name = "Dzik", Id = 1},
                new User { Name = "Pingwin", Id = 2},
            };

            var viewusers = new User
            {
                Users = users
            };

            return View(viewusers);

        }

        // GET: /Users/Details/id
        [Route("Users/Details/{id}")]
        public ActionResult Details(int id)
        {
           
           return View();

        }
    }
}