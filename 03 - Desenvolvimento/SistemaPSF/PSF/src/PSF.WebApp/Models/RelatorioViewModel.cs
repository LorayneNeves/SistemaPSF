using PSF.Dominio.Entities;

namespace PSF.WebApp.Models
{
    public class RelatorioViewModel
    {
        public DateTime Data { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int IndicadorId { get; set; }
        public Indicador Indicador { get; set; }
        public int Valor { get; set; }

        // Outras propriedades e métodos conforme necessário
    }

}
