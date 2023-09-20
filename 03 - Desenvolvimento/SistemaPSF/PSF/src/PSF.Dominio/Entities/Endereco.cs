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
        public int enderecoId { get; set; }
        public string rua { get; set; }
        public Bairro bairro { get; set; }
        public int numero { get; set; }
        public string Cep { get; set; }
        public Cidade cidade { get; set; }
    }
}
