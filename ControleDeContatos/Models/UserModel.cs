using ControleDeContatos.Enums;
using ControleDeContatos.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o e-mail do usuário")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe o perfil do usuário")]
        public ProfileEnum? Profile { get; set; }
        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public virtual List<ContactModel> Contacts { get; set; }

        public bool IsPasswordValid(string password)
        {
            return Password == password.GenerateHash();
        }

        public void SetSenhaHash()
        {
            Password = Password.GenerateHash();
        }

        public void SetNovaSenha(string novaSenha)
        {
            Password = novaSenha.GenerateHash();
        }

        public string GenerateNewPassword()
        {
            string newPassword = Guid.NewGuid().ToString().Substring(0, 8);
            Password = newPassword.GenerateHash();
            return newPassword;
        }
    }
}
