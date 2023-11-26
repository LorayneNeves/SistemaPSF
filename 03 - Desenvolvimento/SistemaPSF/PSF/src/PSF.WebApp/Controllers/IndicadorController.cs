using Microsoft.AspNetCore.Mvc;
using PSF.Dados.EntityFramework;
using PSF.Dominio.Entities;

namespace PSF.WebApp.Controllers
{
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
        
    }
}
