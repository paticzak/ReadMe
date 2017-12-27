using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smile;
using Smile.Learning;

namespace ReadMe.Controllers
{
    public class BayesianNetworkController : Controller
    {
        [AllowAnonymous]
        // GET: /BayesianNetwork/
        public ActionResult Index()
        {
            try
            {
                //Network net = new Network();
                //net.ReadFile(@"C:\Users\Patrycja\Desktop\Praca inzynierska\nastroj-ksiazka-kategoria-okrojone-poprawione.xdsl");

            }
            catch (SmileException e)
            {
                return View(e.Message);
            }
           
            return View();
        }
	}
}