using Microsoft.AspNetCore.Mvc;
using ServidorASP.Clases;

namespace ServidorASP.Controllers
{
    public class LinksController : Controller
    {
        GitHubAPI gitHubAPI = new GitHubAPI("estuardodev", "Servidor2024");

        public LinksController() { }

        public IActionResult Index()
        {
            var data = gitHubAPI.getProfile();
            var license = gitHubAPI.getLicense();
            var repository = gitHubAPI.getRepository();

            ViewBag.Avatar = data["avatar_url"];
            ViewBag.Name = data["name"];
            ViewBag.Username = data["login"];
            ViewBag.License = license["name"];
            ViewBag.RepositoryURL = repository["html_url"];
            ViewBag.LicenceURL = license["url"];

            return View();
        }
    }
}
