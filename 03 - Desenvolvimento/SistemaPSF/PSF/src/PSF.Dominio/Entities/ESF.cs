﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.Entities
{
    public class ESF
    {
        public int EsfId { get; set; }

        public Endereco Enderecos { get; set; }
        public int EnderecoId { get; set; }

        public string Nome { get; set; }
        public bool Status { get; set; }
    }
}
