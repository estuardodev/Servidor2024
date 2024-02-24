using Microsoft.AspNetCore.Mvc;
using ServidorASP.Models;
using System.Diagnostics;

namespace ServidorASP.Controllers
{
    public class PortafolioController : Controller
    {
        private readonly ILogger<PortafolioController> _logger;
        private readonly RailwayContext _dbServerContext;

        public PortafolioController(ILogger<PortafolioController> logger, RailwayContext dbServerContext)
        {
            _logger = logger;
            _dbServerContext = dbServerContext;
        }

        public IActionResult Index()
        {
            ViewBag.AboutMe = _dbServerContext.PortafolioPortafolios.FirstOrDefault(e => e.Id == 1);
            ViewBag.Skills = _dbServerContext.PortafolioHabilidades.OrderBy(e => e.Id).ToList();
            ViewBag.Projects = _dbServerContext.PortafolioProyectos.OrderBy(e => e.Id).ToList();
            ViewBag.Certifications = _dbServerContext.PortafolioCertificaciones.OrderBy(e => e.Id).ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Index(PortafolioEmail portafolioEmail)
        {
            ViewBag.AboutMe = _dbServerContext.PortafolioPortafolios.FirstOrDefault(e => e.Id == 1);
            ViewBag.Skills = _dbServerContext.PortafolioHabilidades.OrderBy(e => e.Id).ToList();
            ViewBag.Projects = _dbServerContext.PortafolioProyectos.OrderBy(e => e.Id).ToList();
            ViewBag.Certifications = _dbServerContext.PortafolioCertificaciones.OrderBy(e => e.Id).ToList();


            Console.WriteLine(portafolioEmail.SubscribeToNewsletter);
            Console.WriteLine(portafolioEmail.EmailAddress);
            if (ModelState.IsValid)
            {
                var existingEmail = _dbServerContext.PortafolioEmails
                    .FirstOrDefault(e => e.EmailAddress == portafolioEmail.EmailAddress && e.SubscribeToNewsletter == true);

                var existingResuscribeEmail = _dbServerContext.PortafolioEmails.FirstOrDefault(e => e.EmailAddress == portafolioEmail.EmailAddress &&
                    e.SubscribeToNewsletter == false);
                if (existingResuscribeEmail != null)
                {
                    existingResuscribeEmail.SubscribeToNewsletter = true;
                    _dbServerContext.SaveChanges();
                    // Si ya está suscrito, también configurar la cookie
                    Response.Cookies.Append("suscrito", "true");
                }

                else if (existingEmail == null)
                {

                    // Guardar en la base de datos
                    _dbServerContext.PortafolioEmails.Add(portafolioEmail);
                    _dbServerContext.SaveChanges();

                    // Configurar la cookie
                    Response.Cookies.Append("suscrito", "true");
                }
                else
                {
                    Response.Cookies.Append("suscrito", "true");
                }
            }
            else
            {
                Console.WriteLine("Error de modelos");
            }

            // Redirigir a la vista después de realizar la acción
            return RedirectToAction("Index");
        }


        public IActionResult Contacto()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contacto(Formulariocontacto formulariocontacto)
        {
            ViewBag.Estado = "";

            if (ModelState.IsValid)
            {
                var es_spam = _dbServerContext.Formulariocontactos.Where(e => e.Correo == formulariocontacto.Correo).ToList();
                if (es_spam != null && (es_spam.Count >= 0 && es_spam.Count < 2))
                {
                    try
                    {
                        formulariocontacto.Fecha = DateTime.Now;
                        _dbServerContext.Formulariocontactos.Add(formulariocontacto);
                        _dbServerContext.SaveChanges();
                        ViewBag.estado = "Correcto";
                    }
                    catch (Exception e)
                    {

                        ViewBag.estado = "Fallo";
                        ViewBag.Error = e;
                    }
                }
                else
                {
                    es_spam[0].EsSpam = true;
                    es_spam[1].EsSpam = true;
                    _dbServerContext.SaveChanges();
                    ViewBag.estado = "Fallo";
                    ViewBag.Error = "Has enviado más 2 correos, tu correo fue seleccionado como spam, así que no fue guardado, si es un error contactame por Twitter.";
                }
            }
            else
            {
                ViewBag.estado = "Fallo";
                ViewBag.Error = "Datos incompletos.";
            }
            return View();
        }

        [Route("/robots.txt")]
        [Host("estuardo.dev")]
        public IActionResult RobotsTxt()
        {
            // Ruta del archivo de texto en la carpeta wwwroot
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Portafolio", "robots.txt");

            // Lee el contenido del archivo
            var contenido = System.IO.File.ReadAllText(filePath);

            // Devuelve el contenido como una cadena de texto
            return Content(contenido, "text/plain");
        }

        [Route("/app-ads.txt")]
        [Route("/ads.txt")]
        [Host("estuardo.dev")]
        public IActionResult AppAds()
        {
            // Ruta del archivo de texto en la carpeta wwwroot
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Portafolio", "app-ads.txt");

            // Lee el contenido del archivo
            var contenido = System.IO.File.ReadAllText(filePath);

            // Devuelve el contenido como una cadena de texto
            return Content(contenido, "text/plain");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
