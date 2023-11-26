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
        public int EventoId { get; set; }
        public Indicador Indicador { get; set; }
        public int IndicadorId { get; set; }
        public DateTime Data { get; set; }
        public int Valor { get; set; }
    }
}
