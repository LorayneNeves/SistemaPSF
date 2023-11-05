using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PSF.Dados.EntityFramework;
using PSF.Dominio.Entities;

namespace PSF.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private Contexto db = new Contexto();

        public IActionResult Index()
        {
            var usuarios = db.Usuario
                .ToList();

            return View(usuarios);
        }

        public IActionResult Inserir()
        {
            var usuario = new Usuario();
            return View(usuario);

        }

        [HttpPost]
        public IActionResult InserirConfirmar(Usuario usuario)
        {
            try
            {
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

        public IActionResult Excluir(int usuarioId)
        {

            var objeto = db.Usuario.FirstOrDefault(f => f.UsuarioId == usuarioId);

            db.Usuario.Remove(objeto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
