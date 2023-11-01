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
        public List <Evento> Eventos { get; set; }
        public string Titulo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public ESF Psf { get; set; }
        public Usuario ACS { get; set; }

    //public string Micro??; 
    }
}
