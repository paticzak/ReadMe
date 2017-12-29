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
        public ActionResult RenderForm(string jakiNastroj, string bookType)
        {            
            Network net = new Network();

            net.ReadFile(@"C:\Users\Patrycja\Desktop\Praca inzynierska\nastroj-ksiazka-kategoria-okrojone-poprawione.xdsl");
            net.UpdateBeliefs();

            //int outcomeIndex;
            double[] FindBiggestValue = new double[10];
            int i = 0;
            
            net.SetEvidence("nastroj", jakiNastroj);
            net.SetEvidence(bookType, "tak");
            net.UpdateBeliefs();

            for (int NodeId = 7; NodeId <= 16; NodeId++)
            {
                String[] aThirdLayerOutcomeIds = net.GetOutcomeIds(net[NodeId]);
                int outcomeIndex1;
                for (outcomeIndex1 = 0; outcomeIndex1 < aThirdLayerOutcomeIds.Length; outcomeIndex1++)
                    if ("tak".Equals(aThirdLayerOutcomeIds[outcomeIndex1]))
                        break;

                double[] pValues = net.GetNodeValue(net[NodeId]);
                double P_ChosenBook = pValues[outcomeIndex1];

                // DODAJĘ WARTOŚCI PRAWDOPODOBIEŃSTW DO TABLICY
                FindBiggestValue[i] = P_ChosenBook;
                i++;

                //Console.WriteLine("P(Nastroj = {0} | JakaKsiazka = {1}) = | \"Gatunek\" {2}) = {3}", userinputNastroj, userInputJakaKsiazka, net[NodeId], P_ChosenBook);
            }

            // ZNAJDUJĘ WARTOŚĆ ORAZ POZYCJĘ NAJWIĘKSZEGO PRAWDOPODOBIEŃSTWA W TABLICY
            double maxNumber = FindBiggestValue.Max();
            int position = Array.IndexOf(FindBiggestValue, maxNumber);
            //Console.WriteLine("max number: " + maxNumber + "index" + position);
            string chosenBookCategory = net[position + 7];

            // WYŚWIETLAM NAZWĘ 
            
            //Console.WriteLine("najbardziej prawdopodobna kategoria książki: " + ChosenBookCategory);

            //if (chosenBookCategory == "refWciag")
                
            //{
            //    //Console.WriteLine("dobry wybór"); 
            //}
            //else
            //{
            //    //Console.WriteLine("inna kategoria niz refWciag");
            //}



            //// "Branie" indexu z konkretnej kategorii
            //String[] aGatunekOutcomeIds = net.GetOutcomeIds("refWciag");
            //for (outcomeIndex = 0; outcomeIndex < aGatunekOutcomeIds.Length; outcomeIndex++)
            //{
            //    if ("tak".Equals(aGatunekOutcomeIds[outcomeIndex]))
            //    {
            //        break;
            //    }
            //}

            //double[] aValues = net.GetNodeValue("refWciag");
            //double P_ChosenBook = aValues[outcomeIndex];

            //ViewBag.ChosenBook = P_ChosenBook;
            ViewBag.UserMood = jakiNastroj;
            ViewBag.BookType = bookType;
            ViewBag.MaxNumber = maxNumber;
            ViewBag.Position = position;
            ViewBag.ChosenBookCategory = chosenBookCategory;

            return View("Index");
        }
    }
}