using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.ValueObjects
{
    public class IndicadorTipo
    {
        public string nenhum { get; set; }
        public string covid { get; set; }
        public string planilhaChecagem { get; set; }
        public string medicacao { get; set; }
        public string vacinacao { get; set; }
    }
}
