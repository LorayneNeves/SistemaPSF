using PSF.Dominio.Entities;
using System.ComponentModel.DataAnnotations;

namespace PSF.WebApp.Models
{
    public class EditarUsuarioViewModel
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public string CPF { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage = "O campo é obrigatório.")]
        public UsuarioTipo Perfil { get; set; }
        public ESF Esf { get; set; }
        [Required(ErrorMessage = "O campo EsfId é obrigatório.")]
        public int EsfId { get; set; }
		[Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }
	}
}
