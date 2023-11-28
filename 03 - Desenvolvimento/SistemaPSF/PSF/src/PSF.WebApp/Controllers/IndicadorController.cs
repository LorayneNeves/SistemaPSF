using Microsoft.AspNetCore.Mvc;
using PSF.Dados.EntityFramework;
using PSF.Dominio.Entities;
using PSF.WebApp.Filters;
using PSF.WebApp.Models;

namespace PSF.WebApp.Controllers
{
    [PaginaUsuarioLogado]
    public class IndicadorController : Controller
    {
        private Contexto db = new Contexto();

        public IActionResult Index()
        {
            var indicadores = db.Indicador
                .ToList();

            return View(indicadores);
        }

        public IActionResult Inserir()
        {
            var indicadores = new Indicador();
            return View(indicadores);
        }

        [HttpPost]
        public IActionResult InserirConfirmar(Indicador indicadores)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Indicador.Add(indicadores);
                    db.SaveChanges();
                    TempData["MensagemSucesso"] = "Indicador cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(indicadores);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos cadastrar o indicador, tente novamente. <br /> Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Editar(int indicadorId)
        {
            var indicador = db.Indicador.FirstOrDefault(u => u.IndicadorId == indicadorId);
            if (indicador == null)
            {
                return NotFound();
            }

            var indicadorViewModel = new EditarIndicadorViewModel
            {
                IndicadorId = indicador.IndicadorId,
                Titulo = indicador.Titulo,
                IndicadorTipo = indicador.IndicadorTipo
            };

            return View(indicadorViewModel);
        }
        [HttpPost]
        public IActionResult EditarConfirmar(EditarIndicadorViewModel indicadorModel)
        {
            try
            {
                var indicadorExistente = db.Indicador.FirstOrDefault(u => u.IndicadorId == indicadorModel.IndicadorId);

                if (indicadorExistente != null)
                {
                    indicadorExistente.Titulo = indicadorModel.Titulo;
                    indicadorExistente.IndicadorTipo = indicadorModel.IndicadorTipo;
                    indicadorExistente.Status = indicadorModel.Status;

                    db.Entry(indicadorExistente).Property(x => x.IndicadorId).IsModified = false;
                    db.SaveChanges();

                    TempData["MensagemSucesso"] = "Indicador atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Indicador não encontrado";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos atualizar o indicador, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

    }
}
