using Acme.API.Models;
using System.ComponentModel.DataAnnotations;

namespace Acme.API.DTOs
{
    public class UsuarioOutputDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

    }
}
