using Microsoft.AspNetCore.Mvc;

namespace ServidorWeb.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int? statusCode)
        {
            if (statusCode.Equals(404))
            {
                return View("404");
            } else if (statusCode.Equals(500))
            {
                return View("500");
            }
            return View();
        }
    }
}
