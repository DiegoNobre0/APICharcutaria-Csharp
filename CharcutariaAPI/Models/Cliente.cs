using CharcutariaAPI.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CharcutariaAPI.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Nome { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Logradouro { get; set; }
        
        [Required]
        [StringLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public int Numero { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Bairro { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Cidade { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Estado { get; set; }

        [Required]
        [StringLength(10)]
        [ValidationCEP(ErrorMessage = "Informe um cep valido XXXXX-XXX")]
        public string? CEP { get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage = "Formato do E-mail inválido")]
        public string? Email { get; set; }

        [Required]
        [StringLength(15)]
        [ValidationCelular(ErrorMessage = "Informe um número valido (XX)9XXXX-XXXX")]
        public string? Celular { get; set; }
        
        [Required]
        [StringLength(15)]
        [ValidationCPF(ErrorMessage = "Informe um CPF válido XXX.XXX.XXX.XX")]
        public string? CPF { get; set; }

        [Required]
        public int FilialId  { get; set; }

        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Logintude { get; set; }

        public Filial Filial { get; set; }

       
    }
}
