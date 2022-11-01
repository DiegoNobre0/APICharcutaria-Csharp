using CharcutariaAPI.Validation;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CharcutariaAPI.Models
{
    public class Filial
    {
        [Key]
        public int FilialId { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string? Cidade { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string Estado { get; set; }

        [Required]
        [StringLength(10)]
        public string CEP { get; set; }

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
        [StringLength(20)]
        [ValidationCNPJ(ErrorMessage = "Informe um CNPJ válido XX.XXX.XXX/XXXX-XX")]
        public string? CNPJ { get; set; }

        [Required]
        public float Latitude { get; set; }
        [Required]
        public float Logintude { get; set; }
        public ICollection<Usuario> Usuarios { get; set; } = new Collection<Usuario>();


        public ICollection<Cliente> Clientes { get; set; } = new Collection<Cliente>();

        
    }
}
