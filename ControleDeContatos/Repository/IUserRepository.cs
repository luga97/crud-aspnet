using ControleDeContatos.Models;
using System.Collections.Generic;

namespace ControleDeContatos.Repositorio
{
    public interface IUserRepository
    {
        UserModel FindByLogin(string login);
        UserModel FindByEmailOrLogin(string email, string login);
        List<UserModel> FindAll();
        UserModel FindById(int id);
        UserModel Add(UserModel usuario);
        UserModel Update(UserModel usuario);
        UserModel ChangePassword(ChangePasswordModel alterarSenhaModel);
        bool Delete (int id);
    }
}
