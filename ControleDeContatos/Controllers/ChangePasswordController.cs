using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeContatos.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISession _session;

        public ChangePasswordController(IUserRepository userRepository,
                                      ISession session)
        {
            _userRepository = userRepository;
            _session = session;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            try
            {
                UserModel LoggedUser = _session.FindUserSession();
                changePasswordModel.Id = LoggedUser.Id;

                if (ModelState.IsValid)
                {
                    _userRepository.ChangePassword(changePasswordModel);
                    TempData["MensagemSucesso"] = "Senha alterada com sucesso!";
                    return View("Index", changePasswordModel);
                }

                return View("Index", changePasswordModel);
            }
            catch (Exception exception)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos alterar sua senha, tente novamante, detalhe do erro: {exception.Message}";
                return View("Index", changePasswordModel);
            }
        }
    }
}
