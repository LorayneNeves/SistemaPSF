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
        public IActionResult Editar(int usuarioId)
        {
            var usuario = db.Usuario.FirstOrDefault(u => u.UsuarioId == usuarioId);
            if (usuario == null)
            {
                return NotFound();
            }

            var esf = db.Esf.ToList();
            ViewBag.Esf = new SelectList(esf, "EsfId", "Nome");

            var usuarioViewModel = new EditarUsuarioViewModel
            {
                UsuarioId = usuario.UsuarioId,
                Nome = usuario.Nome,
                CPF = usuario.CPF,
                Email = usuario.Email,
                Status = usuario.Status,
                Perfil = usuario.Perfil,
                EsfId = usuario.EsfId
            };

            return View(usuarioViewModel);
        }

        [HttpPost]
        public IActionResult EditarConfirmar(EditarUsuarioViewModel usuarioModel)
        {
            try
            {
                var usuarioExistente = db.Usuario.FirstOrDefault(u => u.UsuarioId == usuarioModel.UsuarioId);

                if (usuarioExistente != null)
                {
                    usuarioExistente.Nome = usuarioModel.Nome;
                    usuarioExistente.CPF = usuarioModel.CPF;
                    usuarioExistente.Email = usuarioModel.Email;
                    usuarioExistente.Status = usuarioModel.Status;
                    usuarioExistente.Perfil = usuarioModel.Perfil;
                    usuarioExistente.EsfId = usuarioModel.EsfId;
                    // db.Entry(usuarioExistente).Property(x => x.CPF).IsModified = false;
                    db.Entry(usuarioExistente).Property(x => x.UsuarioId).IsModified = false;

                    // Salva as alterações no banco de dados
                    db.SaveChanges();

                    TempData["MensagemSucesso"] = "Usuário atualizado com sucesso";

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Usuário não encontrado";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos atualizar o usuário, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
