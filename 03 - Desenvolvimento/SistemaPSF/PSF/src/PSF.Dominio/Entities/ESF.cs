using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.Entities
{
    public class ESF
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
