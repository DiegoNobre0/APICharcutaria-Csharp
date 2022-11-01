using CharcutariaAPI.Context;
using CharcutariaAPI.Models;
using CharcutariaAPI.Pagination;
using CharcutariaAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CharcutariaAPI.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Usuario>> GetClientePorNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
            {
                var usuario = await Get().Where(usuario => usuario.Nome.Contains(nome)).ToListAsync();
                return usuario;
            }
            else
            {
                var usuario = await Get().ToListAsync();
                return usuario;
            }
        }
        
    }
}
