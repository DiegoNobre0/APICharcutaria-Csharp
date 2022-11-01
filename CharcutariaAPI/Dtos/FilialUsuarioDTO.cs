using CharcutariaAPI.Models;
using System.Text.Json.Serialization;

namespace CharcutariaAPI.Dtos
{
    public class FilialUsuarioDTO
    {
        public int FilialId { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }
        public string? Logradouro { get; set; }
        public int Numero { get; set; }
        public string? Bairro { get; set; }
        public string? CNPJ { get; set; }

        public ICollection<UsuarioDTO> Usuarios { get; set; }


    }
}
