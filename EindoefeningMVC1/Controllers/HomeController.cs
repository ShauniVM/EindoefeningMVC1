using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EindoefeningMVC1.Models;
using EindoefeningMVC1.Services;
using Microsoft.AspNetCore.Http;
using System.Text;
using Newtonsoft.Json.Schema;

namespace EindoefeningMVC1.Controllers
{
    public class HomeController : Controller
    {
        private PersoonService _persoonService;
        private BestemmingenService _bestemmingenService;

        public HomeController(PersoonService persoonService, BestemmingenService bestemmingenService)
        {
            _persoonService = persoonService;
            _bestemmingenService = bestemmingenService;
        }

        public IActionResult Index()
        {
            if (Request.Cookies["Bezocht"] == null)
                return RedirectToAction("geenBezoeker");
            return View();
        }

        [HttpPost]
        public IActionResult Toevoegen(BestemmingModel b)
        {
            _bestemmingenService.Add(b);
            var Bestemmingen = _bestemmingenService.ShowAll();

            string bestemmingenSessionString = String.Join(" ", Bestemmingen);

            HttpContext.Session.SetString("bestemmingen", bestemmingenSessionString);

            ViewBag.bestemmingen = HttpContext.Session.GetString("bestemmingen");
            return View("Index");
        }

        public IActionResult Wissen(string bestemming, List<string> bestemmingen)
        {
            int index = bestemming.IndexOf(bestemming);
            bestemmingen.RemoveAt(index);
            string sessionString = string.Join(" ", bestemmingen);
            HttpContext.Session.SetString("bestemmingen", (string)sessionString);

            ViewBag.bestemmingen = HttpContext.Session.GetString("bestemmingen");
            return View("Index");
        }

        public IActionResult SessionLeeg()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult geenBezoeker()
        {
            var persoon = new Persoon();
            Response.Cookies.Append("Bezocht", DateTime.Now.ToString());
            return View(persoon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult geenBezoeker(Persoon p)
        {
            if (this.ModelState.IsValid)
            {
                _persoonService.Add(p);
                Response.Cookies.Append("Voornaam", p.Voornaam);
                return RedirectToAction("Index");
            }
            else
                return View(p);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
