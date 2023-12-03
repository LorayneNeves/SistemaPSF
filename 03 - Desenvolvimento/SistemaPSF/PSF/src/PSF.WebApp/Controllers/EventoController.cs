using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PSF.Dados.EntityFramework;
using PSF.Dominio.Entities;
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
        public IActionResult Inserir()
        {

           // var esf = db.Indicador.ToList();
           // ViewBag.Indicador = new SelectList(esf, "EsfId", "Nome");
            var evento = new Evento();
            return View(evento);

        }
        [HttpPost]
        public IActionResult IMAB_Confirmar([FromBody]List<IMAPRespostaViewModel> entidade, int selectMes, int selectAno)
        {
            try
            {
                if (entidade == null || entidade.Count == 0)
                {
                    return BadRequest(new { success = false, message = "Nenhum dado recebido para registro" });
                }

                foreach (var resposta in entidade)
                {
                    var dataEvento = new DateTime(selectAno, selectMes, 1);

                    var evento = new Evento
                    {
                        IndicadorId = resposta.IndicadorId,
                        Data = dataEvento,
                        Valor = resposta.Valor
                    };

                    db.Evento.Add(evento);
                }
                db.SaveChanges();
                TempData["MensagemSucesso"] = "Valores do IMAB registrados com sucesso";
                return Json(new { success = true, message = "Valores do IMAB registrados com sucesso" });
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao registrar valores do IMAB: {ex.Message}";
                return Json(new { success = false, message = $"Erro ao registrar valores do IMAB: {ex.Message}" });
            }
        }
        public IActionResult EventosPorMes(int mesSelecionado)
        {
            var eventos = db.Evento.Where(e => e.Data.Month == mesSelecionado).ToList();

            var viewModel = new EventosPorMesViewModel
            {
                Eventos = eventos,
                MesSelecionado = mesSelecionado
            };

            return View(viewModel);
        }

    }
}
