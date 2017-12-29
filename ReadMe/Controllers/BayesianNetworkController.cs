using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smile;
using Smile.Learning;

namespace ReadMe.Controllers
{
    [AllowAnonymous]
    public class BayesianNetworkController : Controller
    {

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

        [HttpPost]
        public ActionResult RenderForm(string jakiNastroj)
        {
            
            Network net = new Network();
            ViewBag.Net = net;

            net.ReadFile(@"C:\Users\Patrycja\Desktop\Praca inzynierska\nastroj-ksiazka-kategoria-okrojone-poprawione.xdsl");
            //net.ReadFile(@"C:\Users\Patrycja\Desktop\Praca inzynierska\ReadMe2.xdsl");
            net.UpdateBeliefs();
            int outcomeIndex;
            string nastroj1 = jakiNastroj;
            //string nastroj1 = Request["jakiNastroj"];

            // Getting the index of the "Failure" outcome:
            net.SetEvidence("nastroj", nastroj1);
            net.SetEvidence("wciagajaca", "tak");
            net.UpdateBeliefs();
            String[] aGatunekOutcomeIds = net.GetOutcomeIds("refWciag");
            for (outcomeIndex = 0; outcomeIndex < aGatunekOutcomeIds.Length; outcomeIndex++)
            {
                if ("tak".Equals(aGatunekOutcomeIds[outcomeIndex]))
                {
                    break;
                }
            }

            double[] aValues = net.GetNodeValue("refWciag");
            double P_ChosenBook = aValues[outcomeIndex];

            ViewBag.chosenBook = P_ChosenBook;

            return View("Index");
        }
    }
}