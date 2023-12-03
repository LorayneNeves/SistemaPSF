using PSF.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }

        public string Rua { get; set; }

        public string Bairro { get; set; }

        public int Numero { get; set; }

        public string Cep { get; set; }

        public Estados Estado { get; set; }

        public Cidades Cidade { get; set; }

        public int EstadoId { get; set; }
        public int CidadeId { get; set; }
    }
}
