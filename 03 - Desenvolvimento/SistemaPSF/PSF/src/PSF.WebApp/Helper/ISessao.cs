using PSF.WebApp.Models;

namespace PSF.WebApp.Helper
{
	public interface ISessao
	{
		public void CriarSessaoDoUsuario(UsuarioViewModel usuarioViewModel);
		public void RemoverSessaoUsuario();
		UsuarioViewModel BuscarSessaoDoUsuario();
	}
}
