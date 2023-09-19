using PSF.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.ValueObjects
{
    public class Evento
    {
        public Indicador indicador { get; set; }
        public DateTime data { get; set; }
        public int valor { get; set; }
    }
}
