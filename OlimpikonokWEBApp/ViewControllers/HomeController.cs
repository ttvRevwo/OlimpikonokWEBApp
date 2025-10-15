using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using OlimpikonokWEBApp.DTOs;
using OlimpikonokWEBApp.Models;

namespace OlimpikonokWEBApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orszagok()
        {
            return View(new OrszagController().GetOrszagok());
        }

        public IActionResult Sportolok()
        {
            List<Sportolo> sportolok = new SportoloController().GetSportolok();
            return View(sportolok);
        }

        public IActionResult ModositasEredmenye(Sportolo modositott)
        {
            if (modositott == null)
            {
                return View("ModositasEredmenye", "Hiba, nincs módosítandó adat");
            }
            modositott.Nev = Request.Form["nev"].ToString();
            modositott.Neme = Request.Form["neme"].ToString() == "1" ? true : false;
            modositott.SzulDatum = Request.Form["szulDatum"].ToString() != "" ? DateTime.Parse(Request.Form["szulDatum"].ToString()) : DateTime.Now;
            modositott.Ermek = int.Parse(Request.Form["ermekSzama"].ToString());
            return View("ModositasEredmenye", new SportoloController().PutSportolo(modositott));
        }

        public IActionResult SportoloKep(int id)
        {
            SportoloDTO sportoloDTO = new SportoloController().GetSportoloDTOById(id);
            return View(sportoloDTO);
        }

        public IActionResult ModositSportolo(int id)
        {
            return View(new SportoloController().GetSportoloDTOById(id));
        }

        public IActionResult TorolSportolo(int id)
        {
            return View();
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
