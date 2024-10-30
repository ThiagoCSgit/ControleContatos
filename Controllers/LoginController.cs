using ControleContatos.Helper;
using ControleContatos.Models;
using ControleUsuario.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly ISessao _sessao;

        public LoginController(IUsuarioRepositorio usuarioRepositio, ISessao sessao) {
			_usuarioRepositorio = usuarioRepositio;
            _sessao = sessao;

		}
        public IActionResult Index()
        {
            // se o usuáiro já estiver logado, redirecionar para a Home.
            if(_sessao.BuscarSessaoDoUsuario() != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid) {
                    UsuarioModel usuario = _usuarioRepositorio.BuscarPorLogin(loginModel.Login);

                    if(usuario != null){
                        if (usuario.PasswordConfirm(loginModel.Password))
                        {
                            _sessao.CriarSessaoDoUsuario(usuario);
                            return RedirectToAction("Index", "Home");
                        }
                        TempData["MensagemErro"] = $"Senha inválida, tente novamente!";

                    }
                    else
                    {
                        TempData["MensagemErro"] = $"Usuário ou senha inválido(s), tente novamente!";
                    }
                }
                return RedirectToAction("Index", "Login");
            }
            catch (Exception error) {
				TempData["MensagemErro"] = $"Ops, realizar seu login, detalhe do erro: {error.Message}";
				return RedirectToAction("Index");
			}
        }
    }
}
