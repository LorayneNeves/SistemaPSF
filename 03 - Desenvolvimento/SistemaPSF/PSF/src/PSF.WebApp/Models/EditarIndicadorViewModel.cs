using PSF.Dominio.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace PSF.WebApp.Models
{
    public class EditarIndicadorViewModel
    {
        public int IndicadorId { get; set; }
        [Required(ErrorMessage = "Insira um título para este indicador")]
        [StringLength(300, ErrorMessage = "O título não pode ter mais de 300 caracteres")]
        public string Titulo { get; set; }
        public IndicadorTipo IndicadorTipo { get; set; }
        public bool Status { get; set; }
    }
}
