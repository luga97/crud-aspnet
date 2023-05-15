using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome do contato")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do contato")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é valido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o celular do contato")]
        [Phone(ErrorMessage = "O celular informado não é valido!")]
        public string NumberPhone { get; set; }

        public int? UserId { get; set; }

        public UserModel User { get; set; }
    }
}
