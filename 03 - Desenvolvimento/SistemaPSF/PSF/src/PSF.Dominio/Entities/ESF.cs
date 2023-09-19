using PSF.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.Entities
{
    public class ESF
    {
        public int esfId { get; set; }
        public Endereco endereco { get; set; }
        public Usuario usuario { get; set; }
    }
}
