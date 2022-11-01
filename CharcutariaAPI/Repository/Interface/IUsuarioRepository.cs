using CharcutariaAPI.Models;
using CharcutariaAPI.Pagination;

namespace CharcutariaAPI.Repository.Interface
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<IEnumerable<Usuario>> GetClientePorNome(string nome);
        
    }
}
