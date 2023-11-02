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
            var dbContext = new Contexto(); // Substitua "SeuDbContext" pelo nome do seu DbContext
            var estados = dbContext.Estados.ToList();
            ViewBag.Estados = estados;
            var usuario = new Usuario();
            // Outras lógicas para a página de cadastro
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
