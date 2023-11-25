using PSF.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        [Required(ErrorMessage = "Informe a rua")]
        public string Rua { get; set; }
        [Required(ErrorMessage = "Informe o bairro")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Informe o numero")]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Informe o CEP")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Informe o estado")]
        public Estados Estado { get; set; }
        [Required(ErrorMessage = "Informe a cidade")]
        public Cidades Cidade { get; set; }

        public int EstadoId { get; set; }
        public int CidadeId { get; set; }
    }
}
