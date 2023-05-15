using ControleDeContatos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace ControleDeContatos.ViewComponents
{
    public class Menu : ViewComponent
    {
        public  IViewComponentResult InvokeAsync()
        {
            string userSession = HttpContext.Session.GetString("sessaoUsuarioLogado");

            if (string.IsNullOrEmpty(userSession)) return null;

            UserModel usuario = JsonConvert.DeserializeObject<UserModel>(userSession);

            return View(usuario);
        }
    }
}
