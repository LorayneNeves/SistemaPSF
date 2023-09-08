using Microsoft.AspNetCore.Mvc;
using PSF.WebApp.Models;

namespace PSF.WebApp.Controllers
{
    public class AutenticacaoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Autenticar(UsuarioViewModel usuarioViewModel)
        {
            return null;
        }
    }
}
