using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PSF.Dados.EntityFramework;
using PSF.Dominio.Entities;
using PSF.WebApp.Filters;

namespace PSF.WebApp.Controllers
{
    [PaginaUsuarioLogado]
    public class CidadeController : Controller
    {
        public Contexto db = new Contexto();
        public List<Cidades> GetCidades(int estadoId)
        {
            var objeto = db.Cidades.Where(f => f.EstadoId == estadoId).ToList();
            return objeto;
        }
    }
}
