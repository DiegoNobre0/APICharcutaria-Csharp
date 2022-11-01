using CharcutariaAPI.Models;
using CharcutariaAPI.Pagination;

namespace CharcutariaAPI.Repository.Interface
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetClientePorNome(string nome);
        

    }
}
