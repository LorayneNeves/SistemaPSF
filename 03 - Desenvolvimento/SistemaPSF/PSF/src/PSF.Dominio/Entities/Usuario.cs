using PSF.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PSF.Dominio.Entities
{
    public class Usuario
    {
        
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public int UsuarioTipoId { get; set; }

        public UsuarioTipo UsuarioTipo { get; set; }

        // public ESF Psf { get; set; }


    }
}
