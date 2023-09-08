namespace PSF.WebApp.Models
{
    public class UsuarioViewModel
    {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool ManterConectado { get; set; }

        public bool Autenticado()
        {
            if (Usuario == "renato" && Senha == "123")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
