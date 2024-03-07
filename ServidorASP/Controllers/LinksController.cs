using Microsoft.AspNetCore.Mvc;

namespace ServidorASP.Controllers
{
    public class LinksController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
