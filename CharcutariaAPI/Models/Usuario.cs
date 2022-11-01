using CharcutariaAPI.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CharcutariaAPI.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Nome { get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage = "Formato do E-mail inválido")]
        public string? Email { get; set; }
        
        [Required]
        [StringLength(14)]
        //[ValidationCelular(ErrorMessage = "Informe um número valido (XX)9XXXX-XXXX")]
        public string? Celular { get; set; }

        [Required]
        [StringLength(14)]        
        //[ValidationCPF(ErrorMessage = "Informe um CPF válido XXX.XXX.XXX.XX")]
        public string? CPF { get; set; }
        
        [Required]
        public int FilialId { get; set; }
        
        public Filial Filial { get; set; }
    }
}
