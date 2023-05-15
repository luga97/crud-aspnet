using ControleDeContatos.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Repositorio
{
    public interface IContactRepository
    {
        List<ContactModel> FindAll(int usuarioId);
        ContactModel FindById(int id);
        ContactModel Add(ContactModel contato);
        ContactModel Update(ContactModel contato);
        bool Apagar (int id);
    }
}
