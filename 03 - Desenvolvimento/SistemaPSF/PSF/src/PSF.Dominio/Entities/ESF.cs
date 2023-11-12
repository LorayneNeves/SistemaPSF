using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.Entities
{
    public class ESF
    {
        
        public int EsfId { get; set; }
        public Endereco Enderecos { get; set; }
        public int EnderecoId { get; set; }
        public string Nome { get; set; }
    }
}
