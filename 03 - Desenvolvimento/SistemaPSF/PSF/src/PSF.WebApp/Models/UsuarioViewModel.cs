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
       
        public bool ManterConectado { get; set; }

        public bool Autenticado()
        {

            using (var context = new Contexto()) // Substitua 'SeuDbContext' pelo contexto do seu banco de dados
            {
                // Consulta o banco de dados para encontrar o usuário com o CPF fornecido
                var usuarioNoBanco = context.Usuario.FirstOrDefault(u => u.CPF == CPF);

                // Verifica se o usuário foi encontrado
                if (usuarioNoBanco != null)
                {
                    // Compara a senha fornecida com a senha armazenada no banco de dados
                    if (usuarioNoBanco.Senha == Senha)
                    {
                        return true; // Autenticação bem-sucedida
                    }
                }
            }

            return false; // Autenticação falhou


            //return CPF == CPF && Senha == Senha;
        }
	

	}
}
