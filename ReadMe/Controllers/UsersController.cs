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
            //var users =  new List<User> 
            //{
            //    new User { Name = "Dzik", Id = 1},
            //    new User { Name = "Pingwin", Id = 2},
            //};

            //var viewusers = new User
            //{
            //    Users = users
            //};

            var users = GetUsers();

            return View(users);

        }

        // GET: /Users/Details/id
        public ActionResult Details(int id)
        {         
              var user = GetUsers().SingleOrDefault(c => c.Id == id);
 
             if (user == null)
                 return HttpNotFound();
 
             return View(user);
         
        }
         private IEnumerable<User> GetUsers()
        {
             return new List<User>
             {
                 new User { Id = 1, Name = "Dzik" },
                 new User { Id = 2, Name = "Pingwin" }
             };
         }
    }
}