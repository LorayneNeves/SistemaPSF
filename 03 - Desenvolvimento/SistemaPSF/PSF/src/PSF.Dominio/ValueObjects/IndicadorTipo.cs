using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.ValueObjects
{
    public enum IndicadorTipo
    {
        Nenhum = 0,
        COVID = 1,
        PlanilhaChecagem = 2,
        Medicacao = 3,
        Vacinacao = 4,
        Outro = 5
    }
}
