using ControleContatos.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome não pode ser vazio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O login não pode ser vazio")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O email não pode ser vazio")]
        [EmailAddress(ErrorMessage = "Esse não é um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O perfil não pode ser vazio")]
        public PerfilEnum Profile {  get; set; }

        [Required(ErrorMessage = "A senha não pode ser vazio")]
        public string Password { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataAtualizacao { get; set; }
        //a "?" significa que o dado não é obrigatório

        public bool PasswordConfirm(string password)
        {
            return password == Password;
        }
    }
}
