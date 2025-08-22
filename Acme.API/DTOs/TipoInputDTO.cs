using System.ComponentModel.DataAnnotations;

namespace Acme.API.DTOs
{
    public class TipoInputDTO
    {
        [Required(ErrorMessage = "Nome do Tipo é obrigatório!")]
        [StringLength(20)]
        public string Nome { get; set; }
    }
}
