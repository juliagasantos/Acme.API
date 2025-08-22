using System.ComponentModel.DataAnnotations;

namespace Acme.API.Models
{
    public class Tipo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Nome { get; set; }
    }
}
