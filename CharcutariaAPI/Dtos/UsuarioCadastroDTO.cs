using System.ComponentModel.DataAnnotations;

namespace CharcutariaAPI.Dtos
{
    public class UsuarioCadastroDTO
    {
        [EmailAddress]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
    }
}
