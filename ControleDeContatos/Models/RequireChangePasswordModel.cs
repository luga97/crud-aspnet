using System.ComponentModel.DataAnnotations;

namespace ControleDeContatos.Models
{
    public class RequireChangePasswordModel
    {
        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Digite o e-mail")]
        public string Email { get; set; }
    }
}
