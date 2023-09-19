using PSF.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.Entities
{
    public class Indicador
    {
        public int indicadorId { get; set; }
        public int codigo { get; set; }
        public string titulo { get; set; }
        public IndicadorTipo indicadorTipo { get; set; }
    }
}
