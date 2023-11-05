using Newtonsoft.Json;
using PSF.Dominio.Entities;
using PSF.WebApp.Models;

namespace PSF.WebApp.Helper
{
	public class Sessao : ISessao
	{
		/// <summary>
		/// private readonly IHttpContextAccessor _httpContext;
		//// </summary>
		/// <param name="httpContext"></param>
		//public Sessao(IHttpContextAccessor httpContext)
		///{
		//	_httpContext = httpContext;
	//}
	//public UsuarioViewModel BuscarSessaoDoUsuario()
	//{
	//	string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");
	//
	//	if (string.IsNullOrEmpty(sessaoUsuario)) return null;
	//
	//	return JsonConvert.DeserializeObject<UsuarioViewModel>(sessaoUsuario);
	//}
	//
	//public void CriarSessaoDoUsuario(UsuarioViewModel usuario)
	//{
	//	string valor = JsonConvert.SerializeObject(usuario);
	//
	//	_httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
	//}
	//
	//public void RemoverSessaoUsuario()
	//{
	//	_httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
	//}


	}
}
