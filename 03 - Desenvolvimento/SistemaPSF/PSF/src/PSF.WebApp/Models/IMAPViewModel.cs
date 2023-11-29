using PSF.Dominio.Entities;

namespace PSF.WebApp.Models
{
    public class IMAPViewModel
    {
        public IMAPViewModel()
        {
            Indicadores = new List<Indicador>();
        }

        public int Mes { get; set; }
        public int Ano { get; set; }

        public IEnumerable<Indicador> Indicadores { get; set; }
        
    }

    public class IMAPRespostaViewModel
    {
        public int IndicadorId { get; set; }
        public int Valor { get; set; }
    }
}
