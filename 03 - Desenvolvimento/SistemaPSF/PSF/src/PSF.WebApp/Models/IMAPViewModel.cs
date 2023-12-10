using PSF.Dominio.Entities;
using System.ComponentModel.DataAnnotations;

namespace PSF.WebApp.Models
{
    public class IMAPViewModel
    {
        public IMAPViewModel()
        {
            Indicadores = new List<Indicador>();
            
        }

        public DateTime startDate { get; set; }
        public DateTime endDate{ get; set; }
        [Display(Name = "Usuário")]
        public int UsuarioId { get; set; }
        public Usuario Usuarios { get; set; }
        public IEnumerable<Indicador> Indicadores { get; set; }
    }

    public class IMAPRespostaViewModel
    {
        public int UsuarioId { get; set; } 
        public int IndicadorId { get; set; }
        public int Valor { get; set; }
    }
}
