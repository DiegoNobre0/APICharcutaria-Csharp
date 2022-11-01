using CharcutariaAPI.Models;
using CharcutariaAPI.Pagination;

namespace CharcutariaAPI.Repository.Interface
{
    public interface IFilialRepository : IRepository<Filial>
    {
        Task<IEnumerable<Filial>> GetFilialPorCidade(string nome);

        Task<IEnumerable<Filial>> GetFilialCliente();
        Task<IEnumerable<Filial>> GetFilialUsuario();
        Task<IEnumerable<Filial>> GetFilial(int id);
        Task<IEnumerable<Filial>> GetUsuario(int id);








    }
}
