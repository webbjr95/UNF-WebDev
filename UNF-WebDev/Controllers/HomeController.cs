using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UNF_WebDev.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Partners()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Specials(string partnerSpecial)
        {
            string returnView = "specials";
            switch (partnerSpecial)
            {
                case "avis":
                    returnView = "Specials-Avis";
                    break;
                case "hertz":
                    returnView = "Specials-Hertz";
                    break;
                case "enterprise":
                    returnView = "Specials-Enterprise";
                    break;
                case "americanAirlines":
                    returnView = "Specials-AmericanAirlines";
                    break;
                case "jetblue":
                    returnView = "Specials-JetBlue";
                    break;
                case "delta":
                    returnView = "Specials-Delta";
                    break;
            }

            return View(returnView);
        }
    }
}