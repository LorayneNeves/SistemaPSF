using Microsoft.AspNetCore.Mvc;
using PSF.WebApp.Filters;

namespace PSF.WebApp.Controllers
{
    [PaginaUsuarioLogado]
    public class RestricaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
