using ControleDeContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class UserWithoutPasswordModel
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
    }
}
