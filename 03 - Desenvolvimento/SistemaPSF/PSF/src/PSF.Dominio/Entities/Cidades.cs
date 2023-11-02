using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.Entities
{
    public class Cidades
    {
        [Key]
        public int CidadeId { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        public Estados Estado { get; set; }
    }
}
