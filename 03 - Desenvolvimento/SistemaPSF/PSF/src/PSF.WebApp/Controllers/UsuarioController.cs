using Microsoft.AspNetCore.Mvc;

namespace PSF.WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
