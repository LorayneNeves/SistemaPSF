using PSF.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.Entities
{
    public class Indicador
    {
        public int IndicadorId { get; set; }
        [Required(ErrorMessage = "Insira um título para este indicador")]
        [StringLength(300, ErrorMessage = "O título não pode ter mais de 300 caracteres")]
        public string Titulo { get; set; }
        public IndicadorTipo IndicadorTipo { get; set; }
        public bool Status {  get; set; }
    }
}
