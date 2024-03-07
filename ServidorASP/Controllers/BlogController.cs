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

        public IActionResult Index(string search, string filter)
        {
            ViewBag.Paquete = _context.Articulos.Where(e => e.EstadoId == 1).OrderByDescending(e => e.Id).Take(16).ToList();
            ViewBag.UltimoArticulo = _context.Articulos.Where(e => e.EstadoId == 1).OrderByDescending(e => e.FechaHoraCreacion).FirstOrDefault();
            ViewBag.Populares = _context.Articulos.Where(e => e.EstadoId == 1).OrderByDescending(e => e.Visitas).Take(7).ToList();
            ViewBag.ActivePosts = true;
            ViewBag.ActiveTendencia = false;
            ViewBag.ActiveReciente = false;
            var licence = gitHubAPI.getLicense();
            ViewBag.License = licence["name"];

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
                switch (filter) {
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
            ViewBag.License = gitHubAPI.getLicense();
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
            ViewBag.License = gitHubAPI.getLicense();

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
        [Route("/Blog/LikeArticle/{articleId}/{estado}")]
        public ActionResult LikeArticle(int articleId, bool estado)
        {
            if (Request.Method == "POST")
            {
                // Obtener el artículo desde la base de datos
                var article = _context.Articulos.FirstOrDefault(a => a.Id == Convert.ToInt32(articleId));

                if (article != null)
                {
                    
                    if (estado)
                    {
                        article.Likes -= 1;
                    }
                    else
                    {
                        article.Likes += 1;
                    }

                    _context.SaveChanges();

                    return Json(new { success = true, likes = article.Likes });
                }
            }

            return Json(new { success = false });
        }

        [HttpPost]
        [Route("/Blog/LikeArticleGET/{articleId}/{estado}")]
        public ActionResult LikeArticleGET(int articleId, bool estado)
        {
            if (Request.Method == "POST")
            {               
                // Obtener el artículo desde la base de datos
                var article = _context.Articulos.FirstOrDefault(a => a.Id == Convert.ToInt32(articleId));

                if (article != null)
                {
                    if (estado)
                    {
                        return Json(new { success = true, likes = article.Likes });
                    }
                    else
                    {
                        return Json(new { success = false, likes = article.Likes });
                    }
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

        [Route("feed/")]
        [Route("feed/tecnologia/")]
        [Route("feed/tendencia/")]
        [Host("estuardodev.com")]
        public IActionResult FeedRss()
        {
            var path = HttpContext.Request.Path;
            List<Articulo> data = null;

            if (path == "/feed/")
            {
                data = _context.Articulos
                .Include(a => a.ArticuloCategoria).ThenInclude(ac => ac.Categoria)
                .Include(e => e.ArticuloAutors).ThenInclude(ec => ec.Autores)
                .Where(e => e.EstadoId == 1 && e.Id != 1)
                .OrderByDescending(e => e.FechaHoraCreacion)
                .Take(60)
                .ToList();
            }
            else if (path == "/feed/tecnologia/")
            {
                data = _context.Articulos
                .Include(a => a.ArticuloCategoria).ThenInclude(ac => ac.Categoria)
                .Include(e => e.ArticuloAutors).ThenInclude(ec => ec.Autores)
                .Where(e => e.EstadoId == 1 && e.Id != 1 && e.ArticuloCategoria.Any(ac => ac.Categoria.Nombre == "Tecnología"))
                .OrderByDescending(e => e.FechaHoraCreacion)
                .Take(60)
                .ToList();
            }
            else if (path == "/feed/tendencia/")
            {
                data = _context.Articulos
                .Include(a => a.ArticuloCategoria).ThenInclude(ac => ac.Categoria)
                .Include(e => e.ArticuloAutors).ThenInclude(ec => ec.Autores)
                .Where(e => e.EstadoId == 1 && e.Id != 1 && e.ArticuloCategoria.Any(ac => ac.Categoria.Nombre == "Tendencia"))
                .OrderByDescending(e => e.FechaHoraCreacion)
                .Take(60)
                .ToList();
            }
            else
            {
                return NotFound();
            }



            var xmlDoc = new XmlDocument();
            var rssNode = xmlDoc.CreateElement("rss");
            rssNode.SetAttribute("version", "2.0");

            var channelNode = xmlDoc.CreateElement("channel");

            var titleNode = xmlDoc.CreateElement("title");
            titleNode.InnerText = "estuardodev";
            channelNode.AppendChild(titleNode);

            var linkNode = xmlDoc.CreateElement("link");
            linkNode.InnerText = "https://estuardodev.com";
            channelNode.AppendChild(linkNode);

            var descriptionNode = xmlDoc.CreateElement("description");
            descriptionNode.InnerText = "Mantente actualizado con las últimas noticias y análisis de nuestro equipo técnico. Desde política hasta entretenimiento, cubrimos todo lo que necesitas saber en nuestro blog de noticias actualizado diariamente.";
            channelNode.AppendChild(descriptionNode);

            foreach (var item in data)
            {
                var itemNode = xmlDoc.CreateElement("item");

                var itemTitleNode = xmlDoc.CreateElement("title");
                itemTitleNode.InnerText = item.Titulo;
                itemNode.AppendChild(itemTitleNode);

                var itemLinkNode = xmlDoc.CreateElement("link");
                itemLinkNode.InnerText = $"https://estuardodev.com{item.RealUrl()}";
                itemNode.AppendChild(itemLinkNode);

                var itemGuidNode = xmlDoc.CreateElement("guid");
                itemGuidNode.InnerText = $"https://estuardodev.com{item.RealUrl()}";
                itemNode.AppendChild(itemGuidNode);

                var itemDescriptionNode = xmlDoc.CreateElement("description");
                itemDescriptionNode.InnerXml = $@"<![CDATA[<a href=""https://estuardodev.com{item.RealUrl()}""><img width=""560"" height=""280"" src=""https://estuardodev.com/media/{item.Image}"" alt=""{item.DescripcionImagen}"" align=""center"" style=""display: block;margin: 0 auto 20px;max-width:100%"" /></a><p>{item.Descripcion}</p><p><a href=""https://estuardodev.com{item.RealUrl()}"" rel=""nofollow"">Leer más</a></p>]]>";
                itemNode.AppendChild(itemDescriptionNode);

                var itemPubDateNode = xmlDoc.CreateElement("pubDate");
                itemPubDateNode.InnerText = item.FechaHoraCreacion?.ToString("R") ?? string.Empty;
                itemNode.AppendChild(itemPubDateNode);

                foreach (var category in item.ArticuloCategoria)
                {
                    var categoryNode = xmlDoc.CreateElement("category");
                    categoryNode.InnerText = category.Categoria.Nombre;
                    itemNode.AppendChild(categoryNode);
                }

                var tagsNode = xmlDoc.CreateElement("tags");
                tagsNode.InnerText = item.Tags;
                itemNode.AppendChild(tagsNode);

                channelNode.AppendChild(itemNode);
            }

            rssNode.AppendChild(channelNode);
            xmlDoc.AppendChild(rssNode);

            return Content(xmlDoc.OuterXml, "application/xml");
        }
    }
}
