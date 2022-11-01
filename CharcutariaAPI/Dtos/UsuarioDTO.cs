using CharcutariaAPI.Models;

namespace CharcutariaAPI.Dtos
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Celular { get; set; }
        public string? CPF { get; set; }
        public string? FilialId { get; set; }


    }
}
