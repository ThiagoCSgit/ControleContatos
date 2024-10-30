using ControleContatos.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace ControleContatos.Helper
{
	public class Sessao : ISessao
	{
		private readonly IHttpContextAccessor _httpContext;

		public Sessao(IHttpContextAccessor httpContext)
		{
			_httpContext = httpContext;
		}
		public UsuarioModel BuscarSessaoDoUsuario()
		{
			string userSession = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

			if (string.IsNullOrEmpty(userSession)) {
				return null;
			}
			return JsonConvert.DeserializeObject<UsuarioModel>(userSession);
		}

		public void CriarSessaoDoUsuario(UsuarioModel usuario)
		{
			string value = JsonConvert.SerializeObject(usuario);
			_httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", value);
		}

		public void RemoverSessaoDoUsuario()
		{
			_httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
		}
	}
}
