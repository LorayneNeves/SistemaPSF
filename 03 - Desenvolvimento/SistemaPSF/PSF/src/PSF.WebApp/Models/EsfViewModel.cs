using Microsoft.AspNetCore.Mvc.Rendering;
using PSF.Dominio.Entities;

namespace PSF.WebApp.Models
{
    public class EsfViewModel
    {
        public SelectList Estados { get; set; }
        public SelectList Cidades { get; set; }
    }
}
