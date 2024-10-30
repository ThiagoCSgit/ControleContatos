using ControleContatos.Enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class UsuarioSemSenhaModel
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
    }
}
