using ControleDeContatos.Data;
using ControleDeContatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleDeContatos.Repositorio
{
    public class ContatoRepositorio : IContactRepository
    {
        private readonly CrudContext _context;

        public ContatoRepositorio(CrudContext bancoContent)
        {
            this._context = bancoContent;
        }

        public ContactModel FindById(int id)
        {
            return _context.Contacts.FirstOrDefault(x => x.Id == id);
        }

        public List<ContactModel> FindAll(int usuarioId)
        {
            return _context.Contacts.Where(x => x.UserId == usuarioId).ToList();
        }

        public ContactModel Add(ContactModel contato)
        {
            _context.Contacts.Add(contato);
            _context.SaveChanges();
            return contato;
        }

        public ContactModel Update(ContactModel contato)
        {
            ContactModel contatoDB = FindById(contato.Id);

            if (contatoDB == null) throw new Exception("Houve um erro na atualização do contato!");

            contatoDB.Name = contato.Name;
            contatoDB.Email = contato.Email;
            contatoDB.NumberPhone = contato.NumberPhone;

            _context.Contacts.Update(contatoDB);
            _context.SaveChanges();

            return contatoDB;
        }

        public bool Apagar(int id)
        {
            ContactModel contatoDB = FindById(id);

            if (contatoDB == null) throw new Exception("Houve um erro na deleção do contato!");

            _context.Contacts.Remove(contatoDB);
            _context.SaveChanges();

            return true;
        }
    }
}
