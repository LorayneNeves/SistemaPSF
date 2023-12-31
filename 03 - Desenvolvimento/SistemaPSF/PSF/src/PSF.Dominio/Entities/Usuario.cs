﻿using PSF.Dominio.ValueObjects;
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

        public string Senha { get; set; }
        [Required(ErrorMessage = "Informe o status do usuário")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public UsuarioTipo Perfil { get; set; }

        public ESF Esf { get; set; }

        public int EsfId { get; set; }

    }
}
