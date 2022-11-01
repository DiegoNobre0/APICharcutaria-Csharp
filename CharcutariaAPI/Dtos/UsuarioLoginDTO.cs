using System.ComponentModel.DataAnnotations;

namespace CharcutariaAPI.Dtos
{
    public class UsuarioLoginDTO
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
