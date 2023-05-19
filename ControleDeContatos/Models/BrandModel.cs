using System;
using System.ComponentModel.DataAnnotations;

namespace BrandsCrud.Models
{
    public class BrandModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o nome da marca.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite a Nacionalidade da marca.")]
        public bool National { get; set; }

        [Required(ErrorMessage = "O status e requerido")]
        public bool Active { get; set; }
    }
}
