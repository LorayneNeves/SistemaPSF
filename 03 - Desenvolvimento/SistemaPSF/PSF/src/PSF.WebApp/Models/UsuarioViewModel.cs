namespace PSF.WebApp.Models
{
    public class UsuarioViewModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool ManterConectado { get; set; }

        public bool Autenticado()
        {
            return Usuario == "renato" && Senha == "123";
        }
    }
}
