using ControleDeContatos.Filters;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    [PaginaRestritaSomenteAdmin]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IContactRepository _contactRepository;

        public UserController(IUserRepository userRepository,
                                 IContactRepository contactRepository)
        {
            _userRepository = userRepository;
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            List<UserModel> users = _userRepository.FindAll();

            return View(users);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            UserModel user = _userRepository.FindById(id);
            return View(user);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            UserModel usuario = _userRepository.FindById(id);
            return View(usuario);
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool apagado = _userRepository.Delete(id);

                if (apagado) TempData["MensagemSucesso"] = "Usuário apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos apagar seu usuário, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu usuário, tente novamante, detalhe do erro: {exception.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult FindContactsByUser(int id)
        {
            List<ContactModel> contacts = _contactRepository.FindAll(id);
            return PartialView("_ContatosUsuario", contacts);
        }

        [HttpPost]
        public IActionResult Criar(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user = _userRepository.Add(user);

                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (Exception exception)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamante, detalhe do erro: {exception.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UserWithoutPasswordModel usuarioSemSenhaModel)
        {
            try
            {
                UserModel user = null;

                if (ModelState.IsValid)
                {
                    user = new UserModel()
                    {
                        Id = usuarioSemSenhaModel.Id,
                        Name = usuarioSemSenhaModel.Name,
                        Login = usuarioSemSenhaModel.Login,
                        Email = usuarioSemSenhaModel.Email,
                        Profile = usuarioSemSenhaModel.Profile
                    };

                    user = _userRepository.Update(user);
                    TempData["MensagemSucesso"] = "Usuário alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu usuário, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
