using PSF.Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.ValueObjects
{
    public class Relatorio
    {
        public Evento Evento { get; set; }
        public string Titulo { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public ESF Esf { get; set; }
        public Usuario ACS { get; set; }

    //public string Micro??; 
    }
}
