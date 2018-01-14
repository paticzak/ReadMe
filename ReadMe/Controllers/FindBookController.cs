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
    public class FindBookController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ArrayHandler(string[] function_param)
        {

            if (function_param.Length > 0)
            {
                //some code                
                return Content("Success");
            }

            return Content("Not working");

        }


        [HttpPost]
        //public ActionResult RenderForm(string userMood, string bookType1, string bookType2)
        public ActionResult RenderForm(string userMood, string[] bookTypes)
        {
            Network net = new Network();

            net.ReadFile(@"C:\Users\Patrycja\Desktop\Praca inzynierska\ReadMeFindBook.xdsl");
            net.UpdateBeliefs();

            double[] FindBiggestValue = new double[10];
            int i = 0;

            net.SetEvidence("nastroj", userMood);
            for (int j = 0; j < bookTypes.Length; j++)
            {
                net.SetEvidence(bookTypes[j], "tak");
            }
            //net.SetEvidence(bookType1, "tak");
            //net.SetEvidence(bookType2, "tak");

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
            string chosenBookCategory = net[position + 7];

            ViewBag.UserMood = userMood;
            //ViewBag.BookType1 = bookType1;
            //ViewBag.BookType2 = bookType2;
            ViewBag.MaxNumber = maxNumber;
            ViewBag.Position = position;
            ViewBag.ChosenBookCategory = chosenBookCategory;

            string category = chosenBookCategory;

            TempData["Category"] = category;

            return RedirectToAction("ShowBooksFromChosenCategory", "Books");
            //return View("Index");  

        }
    }
}