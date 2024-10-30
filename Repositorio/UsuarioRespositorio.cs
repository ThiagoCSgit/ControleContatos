using ControleContatos.Data;
using ControleContatos.Models;
using ControleUsuario.Repositorio;

namespace ControleContatos.Repositorio
{
    public class UsuarioRespositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRespositorio(BancoContext bancoContext) { 
            _bancoContext = bancoContext;
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            // gravar no banco de dados
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuarios.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }
        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }
        public UsuarioModel Atualizar(UsuarioModel usuario)
        {

            Console.WriteLine("repositiorio:" + usuario.Login);
            UsuarioModel usuarioDB = ListarPorId(usuario.Id);
            if (usuarioDB == null) {
                throw new Exception("Houve um erro na atualização do contato");
            }

            usuarioDB.Name = usuario.Name;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.Profile = usuario.Profile;
            usuarioDB.DataAtualizacao = DateTime.Now;
            

            _bancoContext.Usuarios.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = ListarPorId(id);
            if (usuarioDB == null)
            {
                throw new Exception("Houve um erro na deleção do usuário");
            }
            _bancoContext.Usuarios.Remove(usuarioDB);
            _bancoContext.SaveChanges();

            return true;
        }

		public UsuarioModel BuscarPorLogin(string login)
		{
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
		}
	}
}
