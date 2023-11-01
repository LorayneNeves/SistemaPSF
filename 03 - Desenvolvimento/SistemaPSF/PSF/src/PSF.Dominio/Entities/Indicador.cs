using PSF.Dominio.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSF.Dominio.Entities
{
    public class Indicador
    {
        public Indicador()
        {
            IndicadorTipo = IndicadorTipo.Nenhum;
        }

        public int IndicadorId { get; set; }
        public string Titulo { get; set; }
        public int IndicadorTipoId { get; set; }

        public IndicadorTipo IndicadorTipo { get; set; }

        public void TestarSwitchCase()
        {
            switch (IndicadorTipo)
            {
                case IndicadorTipo.Nenhum:
                    break;
                case IndicadorTipo.COVID:
                    break;
                case IndicadorTipo.PlanilhaChecagem:
                    break;
                case IndicadorTipo.Medicacao:
                    break;
                case IndicadorTipo.Vacinacao:
                    break;
                case IndicadorTipo.Outro:
                    break;
                default:
                    break;
            }
        }

    }
}
