using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServidorASP.Models;
using System.Linq;

namespace ServidorWeb.Controllers
{
    public class BlogController : Controller
    {
        private readonly RailwayContext _context;

        public BlogController(RailwayContext context) { _context = context; }

        public IActionResult Index(string search, string filter)
        {
            ViewBag.Paquete = _context.Articulos.Where(e => e.EstadoId == 1).OrderByDescending(e => e.Id).Take(16).ToList();
            ViewBag.UltimoArticulo = _context.Articulos.Where(e => e.EstadoId == 1).OrderByDescending(e => e.FechaHoraCreacion).FirstOrDefault();
            ViewBag.Populares = _context.Articulos.Where(e => e.EstadoId == 1).OrderByDescending(e => e.Visitas).Take(7).ToList();
            ViewBag.ActivePosts = true;
            ViewBag.ActiveTendencia = false;
            ViewBag.ActiveReciente = false;

            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = _context.Articulos.Where(e => e.EstadoId == 1 && e.Contenido.Contains(search) || e.Titulo.Contains(search) ||
                    e.Tags.Contains(search)).ToList();
                if (ViewBag.Search == null)
                {
                    ViewBag.Search = "No";
                }
                ViewBag.SearchContent = search;
            }

            if (!string.IsNullOrEmpty(filter))
            {
                switch (filter){
                    case "posts":
                        ViewBag.Paquete = _context.Articulos.Where(e => e.EstadoId == 1).OrderByDescending(e => e.Id).Take(16).ToList();
                        ViewBag.ActivePosts = true;
                        break;
                    case "tendencias":
                        ViewBag.ActivePosts = false;
                        ViewBag.ActiveTendencia = true;
                        ViewBag.Paquete = _context.Articulos.Where(e => e.EstadoId == 1).OrderByDescending(e => e.Visitas).Take(8).ToList();
                        break;
                    case "recent":
                        ViewBag.ActivePosts = false;
                        ViewBag.ActiveReciente = true;
                        ViewBag.Paquete = _context.Articulos.Where(e => e.EstadoId == 1).OrderByDescending(e => e.FechaHoraCreacion).Take(12).ToList();
                        break;
                    default:
                        ViewBag.Paquete = _context.Articulos.Where(e => e.EstadoId == 1).OrderByDescending(e => e.Id).Take(16).ToList();
                        ViewBag.ActivePosts = true;
                        break;
                }
            }

            return View();
        }

        [Route("articulos/{url}/{id}/")]
        public IActionResult Articulo(int id)
        {
            var articulo = _context.Articulos
                .Include(a => a.ArticuloCategoria).ThenInclude(ac => ac.Categoria)
                .Include(e => e.ArticuloAutors).ThenInclude(ec => ec.Autores)
                .FirstOrDefault(e => e.Id == id);
            if (articulo == null) { return NotFound(); }

            var articuloRandom = _context.Articulos.OrderByDescending(a => a.Visitas).Take(5).ToList();
            Random random = new Random();
            var indice = random.Next(0, articuloRandom.Count);
            ViewBag.Aleatorio = articuloRandom[indice];

            ViewBag.ArticuloRender = articulo;
            articulo.Visitas += 1;
            _context.SaveChanges();

            return View("Articulo/ArticuloIndex");
        }

        [Route("articulos/")]
        public IActionResult Articulos(string search, string filter)
        {
            ViewBag.Paquete = _context.Articulos.Where(e => e.EstadoId == 1 && e.Id != 1).OrderByDescending(e => e.FechaHoraCreacion).ToList();
            ViewBag.UltimoArticulo = _context.Articulos.Where(e => e.EstadoId == 1 && e.Id != 1).OrderByDescending(e => e.FechaHoraCreacion).FirstOrDefault();
            ViewBag.ActivePosts = true;
            ViewBag.ActiveTendencia = false;
            ViewBag.ActiveReciente = false;

            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = _context.Articulos.Where(e => e.EstadoId == 1 && e.Contenido.Contains(search) || e.Titulo.Contains(search) ||
                    e.Tags.Contains(search)).ToList();
                if (ViewBag.Search == null)
                {
                    ViewBag.Search = "No";
                }
                ViewBag.ActivePosts = false;
                ViewBag.SearchContent = search;
            }

            if (!string.IsNullOrEmpty(filter))
            {
                switch (filter)
                {
                    case "posts":
                        ViewBag.Paquete = _context.Articulos.Where(e => e.EstadoId == 1 && e.Id != 1).OrderByDescending(e => e.Id).ToList();
                        ViewBag.ActivePosts = true;
                        break;
                    case "tendencias":
                        ViewBag.ActivePosts = false;
                        ViewBag.ActiveTendencia = true;
                        ViewBag.Paquete = _context.Articulos.Where(e => e.EstadoId == 1 && e.Id != 1).OrderByDescending(e => e.Visitas).Take(8).ToList();
                        break;
                    case "recent":
                        ViewBag.ActivePosts = false;
                        ViewBag.ActiveReciente = true;
                        ViewBag.Paquete = _context.Articulos.Where(e => e.EstadoId == 1 && e.Id != 1).OrderByDescending(e => e.FechaHoraCreacion).Take(12).ToList();
                        break;
                    default:
                        ViewBag.Paquete = _context.Articulos.Where(e => e.EstadoId == 1 && e.Id != 1).OrderByDescending(e => e.Id).ToList();
                        ViewBag.ActivePosts = true;
                        break;
                }
            }

            return View("All");
        }

        [HttpPost]
        public ActionResult LikeArticle(int articleId)
        {
            if (Request.Method == "POST")
            {
                // Obtener el artículo desde la base de datos
                var article = _context.Articulos.FirstOrDefault(a => a.Id == articleId);

                if (article != null)
                {
                    var userIp = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    var likesIpList = !string.IsNullOrEmpty(article.IpLikes) ? article.IpLikes.Split(',') : new string[0];

                    if (likesIpList.Contains(userIp))
                    {
                        article.Likes -= 1;
                        likesIpList = likesIpList.Except(new[] { userIp }).ToArray();
                    }
                    else
                    {
                        article.Likes += 1;
                        likesIpList = likesIpList.Concat(new[] { userIp }).ToArray();
                    }

                    article.IpLikes = string.Join(",", likesIpList);
                    _context.SaveChanges();

                    return Json(new { success = true, likes = article.Likes });
                }
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IncrementarCompartidos(int id)
        {
            if (Request.Method == "POST")
            {
                // Obtener el artículo desde la base de datos
                var articulo = _context.Articulos.FirstOrDefault(a => a.Id == id);

                if (articulo != null)
                {
                    articulo.Compartidos += 1;
                    _context.SaveChanges();

                    return Json(new { message = "Gracias por compartir mi artículo." });
                }
                else
                {
                    Response.StatusCode = 404; // Establecer el código de estado 404
                    return Json(new { error = "Artículo no encontrado" });
                }
            }
            else
            {
                Response.StatusCode = 405; // Establecer el código de estado 405
                return Json(new { error = "Método no permitido" });
            }
        }

    }
}
