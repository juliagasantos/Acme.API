using Acme.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Acme.API.DTOs
{
    public class UsuarioInputDTO
    {
        [Required(ErrorMessage = "Nome é obrigatório")] 
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é obrigatório")]
        public string Senha { get; set; }
    }
}
