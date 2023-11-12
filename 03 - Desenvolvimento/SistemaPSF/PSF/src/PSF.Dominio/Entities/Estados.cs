using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.Entities
{
    public class Estados
    {
        [Key]
        public int EstadoId { get; set; }
        public string Nome { get; set; }
    }
}
