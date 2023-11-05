using Microsoft.AspNetCore.Mvc;
using PSF.Dominio.Entities;
using PSF.WebApp.Models;

namespace PSF.WebApp.Controllers
{
    public class AutenticacaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Autenticar(UsuarioViewModel usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (usuario.Autenticado())
                    {
                        return base.RedirectToAction("Index", "Home");
                    }
                }
                TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MenssagemErro"] = $"Ops,não conseguimos realizar seu login, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

