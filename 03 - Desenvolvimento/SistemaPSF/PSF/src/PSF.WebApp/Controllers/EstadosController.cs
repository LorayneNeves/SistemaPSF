using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PSF.Dados.EntityFramework;
using PSF.Dominio.Entities;

namespace PSF.WebApp.Controllers
{
    public class EstadosController : Controller
    {
        private Contexto db = new Contexto();

        public IActionResult Index()
        {
            var estado = db.Estados
                .ToList();

            return View(estado);
        }

        
        
    }
}
