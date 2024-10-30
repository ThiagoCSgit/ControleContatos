using ControleContatos.Models;

namespace ControleUsuario.Repositorio
{
    public interface IUsuarioRepositorio
    {

        UsuarioModel BuscarPorLogin(string login);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel contato);

        UsuarioModel ListarPorId(int id);

        UsuarioModel Atualizar(UsuarioModel contato);

        bool Apagar(int id);
    }
}
