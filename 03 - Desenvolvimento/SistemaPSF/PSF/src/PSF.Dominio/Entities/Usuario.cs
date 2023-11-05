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
        [Required(ErrorMessage ="Digite o nome do usuário")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o CPF do usuário")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "Digite o e-mail o usuário")]
        [EmailAddress(ErrorMessage ="O e-mail informado não é valido")]
        public string Email { get; set; }
        public bool Status { get; set; }
        public int UsuarioTipo { get; set; }

        

        // public ESF Psf { get; set; }


    }
}
