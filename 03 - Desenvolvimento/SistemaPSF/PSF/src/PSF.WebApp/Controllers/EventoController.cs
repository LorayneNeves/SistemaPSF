using Microsoft.AspNetCore.Mvc;
using PSF.Dados.EntityFramework;
using PSF.Dominio.ValueObjects;
using PSF.WebApp.Filters;
using PSF.WebApp.Models;

namespace PSF.WebApp.Controllers
{
    [PaginaUsuarioLogado]
    public class EventoController : Controller
    {
        private Contexto db = new Contexto();

        public IActionResult IMAB()
        {
            var entidade = new IMAPViewModel {
                Indicadores = db.Indicador.ToList()
            };

            return View(entidade);
        }

        [HttpPost]
        public IActionResult IMAB_Confirmar([FromBody]List<IMAPRespostaViewModel> entidade)
        {
            return null;
        }
    }
}
