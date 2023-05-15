using ControleDeContatos.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace ControleDeContatos.Helper
{
    public class Session : ISession
    {
        private readonly IHttpContextAccessor _httpContext;

        public Session(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public UserModel FindUserSession()
        {
            string sessaoUsuario = _httpContext.HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(sessaoUsuario)) return null;

            return JsonConvert.DeserializeObject<UserModel>(sessaoUsuario);
        }

        public void CreateUserSession(UserModel usuario)
        {
            string valor = JsonConvert.SerializeObject(usuario);

            _httpContext.HttpContext.Session.SetString("sessaoUsuarioLogado", valor);
        }

        public void RemoveUserSession()
        {
            _httpContext.HttpContext.Session.Remove("sessaoUsuarioLogado");
        }
    }
}
