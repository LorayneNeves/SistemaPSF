using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using PSF.WebApp.Models;

namespace PSF.WebApp.Filters
{
    public class PaginaRestritaAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sessaoUsuario = context.HttpContext.Session.GetString("sessaoUsuarioLogado");
            if (string.IsNullOrEmpty(sessaoUsuario))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Autenticacao" }, { "action", "Index" } });
            }
            else
            {
                UsuarioViewModel usuario = JsonConvert.DeserializeObject<UsuarioViewModel>(sessaoUsuario);
                if (usuario == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Autenticacao" }, { "action", "Index" } });
                }
                else if (usuario.Perfil != Dominio.Entities.UsuarioTipo.Admin)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Restricao" }, { "action", "Index" } });
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
