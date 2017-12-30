using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Smile;
using Smile.Learning;
using ReadMe.Models;
using ReadMe.ViewModels;

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
        public ActionResult RenderForm(string userMood, string bookType1, string bookType2)
        {            
            Network net = new Network();

            net.ReadFile(@"C:\Users\Patrycja\Desktop\Praca inzynierska\nastroj-ksiazka-kategoria-okrojone-poprawione.xdsl");
            net.UpdateBeliefs();

            double[] FindBiggestValue = new double[10];
            int i = 0;
            
            net.SetEvidence("nastroj", userMood);
            if(bookType2 == "")
            {
                net.SetEvidence(bookType1, "tak");
            }
            if(bookType1 != "" && bookType2 != "")
            {
                net.SetEvidence(bookType1, "tak");
                net.SetEvidence(bookType2, "tak");
            }
           
            net.UpdateBeliefs();

            for (int NodeId = 7; NodeId <= 16; NodeId++)
            {
                String[] aThirdLayerOutcomeIds = net.GetOutcomeIds(net[NodeId]);
                int outcomeIndex;
                for (outcomeIndex = 0; outcomeIndex < aThirdLayerOutcomeIds.Length; outcomeIndex++)
                    if ("tak".Equals(aThirdLayerOutcomeIds[outcomeIndex]))
                        break;

                double[] pValues = net.GetNodeValue(net[NodeId]);
                double P_ChosenBook = pValues[outcomeIndex];

                // DODAJĘ WARTOŚCI PRAWDOPODOBIEŃSTW DO TABLICY
                FindBiggestValue[i] = P_ChosenBook;
                i++;
            }

            // ZNAJDUJĘ WARTOŚĆ ORAZ POZYCJĘ NAJWIĘKSZEGO PRAWDOPODOBIEŃSTWA W TABLICY
            double maxNumber = FindBiggestValue.Max();
            int position = Array.IndexOf(FindBiggestValue, maxNumber);
            //Console.WriteLine("max number: " + maxNumber + "index" + position);
            string chosenBookCategory = net[position + 7];

            //ViewBag.ChosenBook = P_ChosenBook;
            ViewBag.UserMood = userMood;
            ViewBag.BookType1 = bookType1;
            ViewBag.BookType2 = bookType2;
            ViewBag.MaxNumber = maxNumber;
            ViewBag.Position = position;
            ViewBag.ChosenBookCategory = chosenBookCategory;

            string category = "Pay as You Go";

            TempData["Category"] = category;

            if (chosenBookCategory == "poz_wciag")
            {
                return RedirectToAction("Index", "Customers");
            }

            return View("Index");
        }
    }
}