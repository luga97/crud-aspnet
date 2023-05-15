using ControleDeContatos.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers
{
    [LoggedUserPage]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
