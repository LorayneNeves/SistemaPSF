namespace PSF.WebApp.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int MyProperty { get; set; }
        public bool ManterConectado { get; set; }

        //public bool Autenticado()
       // {
           // return Usuario == "renato" && Senha == "123";
       // }
    }
}
