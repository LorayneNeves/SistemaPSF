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
            IndicadorTipo = IndicadorTipoEnum.Nenhum;
        }

        public int IndicadorId { get; set; }
        public string Titulo { get; set; }
        public int IndicadorTipoId { get; set; }

        public IndicadorTipoEnum IndicadorTipo { get; set; }

        public void TestarSwitchCase()
        {
            switch (IndicadorTipo)
            {
                case IndicadorTipoEnum.Nenhum:
                    break;
                case IndicadorTipoEnum.COVID:
                    break;
                case IndicadorTipoEnum.PlanilhaChecagem:
                    break;
                case IndicadorTipoEnum.Medicacao:
                    break;
                case IndicadorTipoEnum.Vacinacao:
                    break;
                case IndicadorTipoEnum.Outro:
                    break;
                default:
                    break;
            }
        }

    }
}
