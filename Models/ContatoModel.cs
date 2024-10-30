using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser vazio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email não pode ser vazio")]
        [EmailAddress(ErrorMessage = "Esse não é um email válido")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "O celular não pode ser vazio")]
        [Phone(ErrorMessage = "Esse não um número válido")]
        public string Cellphone {  get; set; }
    }
}
