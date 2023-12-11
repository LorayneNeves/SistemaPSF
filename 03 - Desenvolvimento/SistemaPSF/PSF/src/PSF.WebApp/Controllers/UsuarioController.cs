using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PSF.Dados.EntityFramework;
using PSF.Dominio.Entities;
using PSF.WebApp.Filters;
using PSF.WebApp.Models;

namespace PSF.WebApp.Controllers
{
    [PaginaRestritaAdmin]
    public class UsuarioController : Controller
    {
        private Contexto db = new Contexto();

        public IActionResult Index()
        {
           var enderecos = db.Usuario.Include(e => e.Esf.Enderecos).ToList();
            var usuarios = db.Usuario
                .ToList();

            return View(usuarios);
        }

        public IActionResult Inserir()
        {
            var esf = db.Esf.ToList();
            ViewBag.Esf = new SelectList(esf, "EsfId", "Nome");
            var usuario = new Usuario();
            return View(usuario);

        }
        [HttpPost]
        public IActionResult InserirConfirmar(Usuario usuario)
        {
            try
            {
                ModelState.Remove("Esf");

                if (ModelState.IsValid)
                {
                    db.Usuario.Add(usuario);
                    db.SaveChanges();
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(usuario);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops! Não conseguimos cadastrar o usuário, tente novamente. <br /> Detalhe do erro: {erro.Message}";
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
                EsfId = usuario.EsfId,
                Senha = usuario.Senha

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
					usuarioExistente.Senha = usuarioModel.Senha;
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

        public IActionResult Excluir(int usuarioId)
        {

            var objeto = db.Usuario.FirstOrDefault(f => f.UsuarioId == usuarioId);

            db.Usuario.Remove(objeto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
