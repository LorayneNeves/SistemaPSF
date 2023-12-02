using Microsoft.EntityFrameworkCore;
using PSF.Dados.EntityFramework;
using PSF.Dominio.Entities;
using System.ComponentModel.DataAnnotations;

namespace PSF.WebApp.Models
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "Digite seu CPF")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }
        public UsuarioTipo Perfil {  get; set; }
        public bool ManterConectado { get; set; }

        public bool Autenticado()
        {

            using (var context = new Contexto())
            {
                var usuarioNoBanco = context.Usuario.FirstOrDefault(u => u.CPF == CPF);
                // Verifica se o usuário foi encontrado
                if (usuarioNoBanco != null)
                {
                    if (usuarioNoBanco.Senha == Senha)
                    {
                        Perfil = usuarioNoBanco.Perfil;

                        return true;
                    }
                }
            }
            return false; 
        }
	

	}
}
