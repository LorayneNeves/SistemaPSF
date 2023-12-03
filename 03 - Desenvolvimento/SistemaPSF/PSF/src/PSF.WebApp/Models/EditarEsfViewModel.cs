using PSF.Dominio.Entities;
using System.ComponentModel.DataAnnotations;

namespace PSF.WebApp.Models
{
    public class EditarEsfViewModel
    {
        public int EsfId { get; set; }
        [Required(ErrorMessage = "Informe o endereço do ESF")]
        public Endereco Enderecos { get; set; }
        public int EnderecoId { get; set; }
        [Required(ErrorMessage = "Digite o nome do ESF")]
        public string Nome { get; set; }
        public bool Status { get; set; }
        
    }
}
