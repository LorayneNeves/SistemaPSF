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
        public int IndicadorId { get; set; }
        public int Codigo { get; set; }
        public string Titulo { get; set; }
        public IndicadorTipo indicadorTipo { get; set; }
    }
}
