using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PSF.Dados.EntityFramework;
using PSF.Dominio.Entities;
using PSF.WebApp.Filters;
using PSF.WebApp.Models;

namespace PSF.WebApp.Controllers
{
    [PaginaUsuarioLogado]
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
            db.Esf.Add(endereco);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public IActionResult Editar(int esfId)
        {
            var estados = db.Estados.ToList();
            var cidades = db.Cidades.ToList();
            // Armazenar a lista de estados na ViewBag
            ViewBag.Estados = new SelectList(estados, "EstadoId", "Nome");
            ViewBag.Cidades = new SelectList(cidades, "CidadeId", "Nome", "EstadoId");
            var esf = db.Esf.FirstOrDefault(u => u.EsfId == esfId);
            if (esf == null)
            {
                return NotFound();
            }

            var end = db.Endereco.ToList();
            ViewBag.Endereco = new SelectList(end, "EnderecoId", "Rua");

            var esfViewModel = new EditarEsfViewModel
            {
                EsfId = esf.EsfId,
                EnderecoId = esf.EnderecoId,
                Status = esf.Status,
                Nome = esf.Nome,
                Enderecos = new Endereco
                {
                    Rua = esf.Enderecos.Rua,
                    Bairro = esf.Enderecos.Bairro,
                    Cep = esf.Enderecos.Cep,
                    CidadeId = esf.Enderecos.CidadeId,
                    EstadoId = esf.Enderecos.EstadoId,
                    Numero = esf.Enderecos.Numero
                }
            };

            return View(esfViewModel);
        }

        [HttpPost]
        public IActionResult EditarConfirmar(EditarEsfViewModel esfModel)
        {
            try
            {
               // var esfExistente = db.Esf.FirstOrDefault(u => u.EsfId == esfModel.EsfId);
                var esfExistente = db.Esf.Include(e => e.Enderecos).FirstOrDefault(u => u.EsfId == esfModel.EsfId);

                if (esfExistente != null)
                {
                    esfExistente.EnderecoId = esfModel.EnderecoId;
                    esfExistente.Status = esfModel.Status;
                    esfExistente.Nome = esfModel.Nome;
                    if (esfModel.Enderecos != null)
                    {
                        esfExistente.Enderecos.Rua = esfModel.Enderecos.Rua;
                        esfExistente.Enderecos.Bairro = esfModel.Enderecos.Bairro;
                        esfExistente.Enderecos.EstadoId = esfModel.Enderecos.EstadoId;
                        esfExistente.Enderecos.Numero = esfModel.Enderecos.Numero;
                        esfExistente.Enderecos.Cep = esfModel.Enderecos.Cep;
                    }

                    db.Entry(esfExistente).Property(x => x.EnderecoId).IsModified = false;

                    db.SaveChanges();

                    TempData["MensagemSucesso"] = "ESF atualizado com sucesso";

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "ESF não encontrado";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos atualizar o ESF, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
