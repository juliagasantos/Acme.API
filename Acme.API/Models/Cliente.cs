using System.ComponentModel.DataAnnotations;

namespace Acme.API.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(14)]
        public string Cpf { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataNascimento { get; set; }
        [Required]
        [StringLength(70)]
        public string Email { get; set; }
        [StringLength(20)]
        public string Telefone { get; set; }

    }
}
