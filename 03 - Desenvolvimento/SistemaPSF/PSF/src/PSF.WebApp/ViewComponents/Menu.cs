using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PSF.Dominio.Entities;
using PSF.WebApp.Models;

namespace PSF.WebApp.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sessaoUsuario = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;
            UsuarioViewModel usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(sessaoUsuario);

            return View(usuario);
        }
    }
}
