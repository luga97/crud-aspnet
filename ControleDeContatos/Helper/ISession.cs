using ControleDeContatos.Models;

namespace ControleDeContatos.Helper
{
    public interface ISession
    {
        void CreateUserSession(UserModel usuario);
        void RemoveUserSession();
        UserModel FindUserSession();
    }
}
