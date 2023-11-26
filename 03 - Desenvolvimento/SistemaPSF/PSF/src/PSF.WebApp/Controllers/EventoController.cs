using Microsoft.AspNetCore.Mvc;
using PSF.Dados.EntityFramework;
using PSF.Dominio.ValueObjects;

namespace PSF.WebApp.Controllers
{
    public class EventoController : Controller
    {
        private Contexto db = new Contexto();

        public IActionResult IMAB()
        {
            var evento = db.Evento
                .ToList();

            return View(evento);
        }
    }
}
