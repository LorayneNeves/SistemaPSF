using Microsoft.AspNetCore.Mvc;
using PSF.Dominio.Entities;
using PSF.WebApp.Helper;
using PSF.WebApp.Models;

namespace PSF.WebApp.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly ISessao _sessao;
        public AutenticacaoController(ISessao sessao)
        {
            _sessao = sessao;
        }
        public IActionResult Index()
        {
            if (_sessao.BuscarSessaoDoUsuario() != null) return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Sair() 
        { 
            _sessao.RemoverSessaoUsuario();

            return RedirectToAction("Index", "Autenticacao");
        }
        [HttpPost]
        public IActionResult Autenticar(UsuarioViewModel usuario)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    if (usuario.Autenticado())
                    {
                        _sessao.CriarSessaoDoUsuario(usuario);
                        return base.RedirectToAction("Index", "Home");
                    }
                }
                TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MenssagemErro"] = $"Ops,não conseguimos realizar seu login, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}

