using Microsoft.AspNetCore.Mvc;
using ServidorASP.Models;

namespace ServidorWeb.Controllers
{
    public class LegalController : Controller
    {
        private readonly RailwayContext _context;
        public LegalController(RailwayContext dbServer)
        {
            _context = dbServer;
        }

        public IActionResult Privacidad()
        {
            ViewBag.Politicas = _context.Privacidads.FirstOrDefault(e => e.Id == 1 && e.Estado == true);
            return View();
        }

        public IActionResult Terminos()
        {
            ViewBag.Terminos = _context.Terminos.FirstOrDefault(e => e.Id == 1 && e.Estado == true);
            return View();
        }

        public IActionResult Cookies()
        {
            ViewBag.Cookies = _context.Cookies.FirstOrDefault(e => e.Id == 1 && e.Estado == true);
            return View();
        }
    }
}
