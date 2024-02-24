using Microsoft.AspNetCore.Mvc;
using ServidorASP.Models;
using ServidorWeb.Clases;
using System.Diagnostics;
using System.Text.Json;

namespace ServidorWeb.Controllers
{
    public class JanoController : Controller
    {
        private readonly RailwayContext _context;
        private readonly string _clientID;
        private readonly string _secretID;
        TwitchAPI twitch;

        public JanoController(RailwayContext context, IConfiguration configuration)
        {
            _context = context;
            _clientID = configuration["TWITCH_CLIENT_ID"];
            _secretID = configuration["TWITCH_SECRET_ID"];
            twitch = new TwitchAPI(_clientID, _secretID);
        }

        public IActionResult Index()
        {
            var live = twitch.live("janoabonce");
            if (!live.Equals("{'message': 'none'}"))
            {
                JsonDocument json = JsonDocument.Parse(live);
                if (json != null)
                {
                    int follows = twitch.followers(json.RootElement[0].GetProperty("user_id").ToString());
                    ViewBag.follows = follows;
                    ViewBag.live = json;

                    var tags = json.RootElement[0].GetProperty("tags").ToString();
                    String[] strings = tags.Split(',');
                    for (int i = 0; i < strings.Length; i++)
                    {
                        strings[i] = strings[i].Trim(new char[] { '[', ']', '"' });
                    }
                    ViewBag.tags = strings;

                    // started_at
                    ViewBag.Tiempo = Tiempo(json.RootElement[0].GetProperty("started_at").ToString());

                }



            }

            ViewBag.Informacion = _context.InformacionJanos.FirstOrDefault(e => e.Id == 1 && e.Estado == true);
            ViewBag.Redes = _context.RedesSocialesJanos.OrderByDescending(e => e.Id).ToList();
            return View();
        }

        public (int, int, int) Tiempo(string hora)
        {
            string tiempo_str = hora;

            // Convertir cadena a objeto DateTime
            // Convertir cadena a objeto DateTime con información de zona horaria UTC
            DateTime tiempo = DateTime.Parse(tiempo_str.Replace("Z", "+00:00")).ToUniversalTime();

            // Obtener tiempo actual con información de zona horaria UTC
            DateTime tiempo_actual = DateTime.UtcNow;

            // Calcular diferencia de tiempo
            TimeSpan diferencia = tiempo_actual - tiempo;

            // Obtener horas, minutos y segundos de la diferencia
            int horas = diferencia.Days * 24 + diferencia.Hours;
            int minutos = diferencia.Minutes;
            int segundos = diferencia.Seconds;

            return (horas, minutos, segundos);
        }
    }
}
