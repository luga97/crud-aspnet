namespace ControleDeContatos.Helper
{
    public interface IEmail
    {
        bool Send(string email, string assunto, string mensagem);
    }
}
