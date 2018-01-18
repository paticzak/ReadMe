using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReadMe.Controllers
{
    
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                return View("AfterLogin");
            }
            return View();
        }

        [Authorize]
        public ActionResult ProposeBook()
        {
            return View("ProposeBook");
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
           return View();
        }
    }
}