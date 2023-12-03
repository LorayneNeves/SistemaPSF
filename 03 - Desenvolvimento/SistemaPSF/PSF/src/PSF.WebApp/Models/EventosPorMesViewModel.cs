using PSF.Dominio.Entities;
using PSF.Dominio.ValueObjects;

namespace PSF.WebApp.Models
{
    public class EventosPorMesViewModel
    {
        public List<Evento> Eventos { get; set; }
        public int MesSelecionado { get; set; }
    }
}
