using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISession _session;
        private readonly IEmail _email;

        public LoginController(IUserRepository userRepository,
                               ISession session,
                               IEmail email)
        {
            _userRepository = userRepository;
            _session = session;
            _email = email; 
        }

        public IActionResult Index()
        {
            if(_session.FindUserSession() != null) return RedirectToAction("Index", "Home");
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public IActionResult Logout()
        {
            _session.RemoveUserSession();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult SignIn(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.FindByLogin(loginModel.Login);

                    if (user != null)
                    {
                        if (user.IsPasswordValid(loginModel.Password))
                        {
                            _session.CreateUserSession(user);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"Senha do usuário é inválida, tente novamente.";
                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
                }

                return View("Index");
            }
            catch (Exception exception)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamante, detalhe do erro: {exception.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult SendPasswordChangeLink(RequireChangePasswordModel changePasswordModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.FindByEmailOrLogin(changePasswordModel.Email, changePasswordModel.Login);

                    if (user != null)
                    {
                        string newPassword = user.GenerateNewPassword();
                        string message = $"Sua nova senha é: {newPassword}";

                        bool emailEnviado = _email.Send(user.Email, "Sistema de Contatos - Nova Senha", message);

                        if (emailEnviado)
                        {
                            _userRepository.Update(user);
                            TempData["MensagemSucesso"] = $"Enviamos para seu e-mail cadastrado uma nova senha.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = $"Não conseguimos enviar e-mail. Por favor, tente novamente.";
                        }

                        return RedirectToAction("Index","Login");
                    }

                    TempData["MensagemErro"] = $"Não conseguimos redefinir sua senha. Por favor, verifique os dados informados.";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos redefinir sua senha, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
