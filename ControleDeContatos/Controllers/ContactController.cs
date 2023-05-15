using ControleDeContatos.Filters;
using ControleDeContatos.Helper;
using ControleDeContatos.Models;
using ControleDeContatos.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ControleDeContatos.Controllers
{
    [LoggedUserPage]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly ISession _session;

        public ContactController(IContactRepository contactRepository,
                                 ISession session)
        {
            _contactRepository = contactRepository;
            _session = session;   
        }

        public IActionResult Index()
        {
            UserModel LoggedUser = _session.FindUserSession();
            List<ContactModel> contacts = _contactRepository.FindAll(LoggedUser.Id);

            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ContactModel contato = _contactRepository.FindById(id);
            return View(contato);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            ContactModel contato = _contactRepository.FindById(id);
            return View(contato);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool apagado = _contactRepository.Apagar(id);

                if(apagado) TempData["MensagemSucesso"] = "Contato apagado com sucesso!"; else TempData["MensagemErro"] = "Ops, não conseguimos cadastrar seu contato, tente novamante!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos apagar seu contato, tente novamante, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel usuarioLogado = _session.FindUserSession();
                    contact.UserId = usuarioLogado.Id;

                    contact = _contactRepository.Add(contact);

                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception exception)
            { 
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu contato, tente novamante, detalhe do erro: {exception.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel usuarioLogado = _session.FindUserSession();
                    contact.UserId = usuarioLogado.Id;

                    contact = _contactRepository.Update(contact);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception exception)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos atualizar seu contato, tente novamante, detalhe do erro: {exception.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
