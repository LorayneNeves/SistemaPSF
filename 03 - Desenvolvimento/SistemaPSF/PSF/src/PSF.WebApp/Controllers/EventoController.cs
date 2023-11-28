using Microsoft.AspNetCore.Mvc;
using PSF.Dados.EntityFramework;
using PSF.Dominio.ValueObjects;
using PSF.WebApp.Filters;

namespace PSF.WebApp.Controllers
{
    [PaginaUsuarioLogado]
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
