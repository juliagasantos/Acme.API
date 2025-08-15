using System.ComponentModel.DataAnnotations;

namespace Acme.API.DTOs
{
    public class ClienteInputDTO
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }

        public string Telefone { get; set; }
    }
}
