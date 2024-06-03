using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServidorASP.Models;
using System.Xml;
using ServidorASP.Clases;

namespace ServidorWeb.Controllers
{
    public class BlogController : Controller
    {
        private readonly RailwayContext _context;
        GitHubAPI gitHubAPI = new GitHubAPI("estuardodev", "Servidor2024");

        public BlogController(RailwayContext context) { _context = context; }

        public IActionResult Index()
        {
            return View();
        }
    }
}
