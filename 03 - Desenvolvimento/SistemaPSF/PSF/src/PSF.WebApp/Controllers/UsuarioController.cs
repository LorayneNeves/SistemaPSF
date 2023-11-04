using Microsoft.AspNetCore.Mvc;
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
        public IActionResult InserirConfirmar(Usuario ent)
        {
            db.Usuario.Add(ent);
            db.SaveChanges();
            return RedirectToAction("Index");
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
