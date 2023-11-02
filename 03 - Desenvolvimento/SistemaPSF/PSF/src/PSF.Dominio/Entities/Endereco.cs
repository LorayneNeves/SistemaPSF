using PSF.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public Bairro bairro { get; set; }
        public int Numero { get; set; }
        public string Cep { get; set; }
        public Estados Estado { get; set; }
        public Cidades Cidade { get; set; }
    }
}
