using ControleContatos.Models;
using ControleContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleContatos.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _contatoRepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Contato apagado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemSucesso"] = "Ops, não conseguimos apagar seu contato";
                }
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["MensagemErro"] = $"Ops, não foi possível apagar seu contato, tente novamente, detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
        //Caso não seja informado o tipo do método (POST, PUT, DELETE) ele será GET por padrão.
        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato criado com sucesso";
                    return RedirectToAction("Index");
                }
                return View(contato);
            }
            catch (Exception error) {
                TempData["MensagemErro"] = $"Ops, não foi possível cadastrar seu contato, tente novamente, detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato atualizado com sucesso";
                    return RedirectToAction("Index");
                }
                return View("Editar", contato);
            }
            catch(Exception error) {
                TempData["MensagemErro"] = $"Ops, não foi possível atuaizar seu contato, tente novamente, detalhe do erro: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
