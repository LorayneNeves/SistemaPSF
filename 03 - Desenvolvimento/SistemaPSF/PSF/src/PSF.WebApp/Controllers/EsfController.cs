using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PSF.Dados.EntityFramework;
using PSF.Dominio.Entities;

namespace PSF.WebApp.Controllers
{
    public class EsfController : Controller
    {
        private Contexto db = new Contexto();

        public IActionResult Index()
        {
            var enderecos = db.Esf.Include(e => e.Enderecos.Cidade).Include(e => e.Enderecos.Estado).ToList();

            var esf = db.Esf
                .ToList();

            return View(esf);
        }

        public IActionResult Inserir()
        {
            var estados = db.Estados.ToList();
            var cidades = db.Cidades.ToList();
            // Armazenar a lista de estados na ViewBag
            ViewBag.Estados = new SelectList(estados, "EstadoId", "Nome");
            ViewBag.Cidades = new SelectList(cidades, "CidadeId", "Nome", "EstadoId");
            var esf = new ESF();
            return View(esf);

        }

        [HttpPost]
        public IActionResult InserirConfirmar(ESF endereco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Esf.Add(endereco);
                    db.SaveChanges();
                    TempData["MensagemSucesso"] = "ESF cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(endereco);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos cadastrar o ESF, tente novamente. <br /> Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
        public IActionResult Excluir(int esfId)
        {
            var objeto = db.Esf.FirstOrDefault(f => f.EsfId == esfId);

            db.Esf.Remove(objeto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
