using CharcutariaAPI.Context;
using CharcutariaAPI.Models;
using CharcutariaAPI.Pagination;
using CharcutariaAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace CharcutariaAPI.Repository
{
    public class FilialRepository : Repository<Filial>, IFilialRepository
    {
        public FilialRepository(AppDbContext context) : base(context)
        {
        }

       

        public async Task<IEnumerable<Filial>> GetFilialPorCidade(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
            {
                var filial = await Get().Where(filial => filial.Cidade.Contains(nome)).ToListAsync();
                return filial;
            }
            else
            {
                var filial = await Get().ToListAsync();
                return filial;
            }
        }

        public async Task<IEnumerable<Filial>> GetFilialCliente()
        {
            return await Get().Include(x => x.Clientes).ToListAsync();
        }

        public async Task<IEnumerable<Filial>> GetFilialUsuario()
        {
            return await Get().Include(x => x.Usuarios).ToListAsync();
        }

        public async Task<IEnumerable<Filial>> GetFilial(int id)
        {
            return await Get().Include(x => x.Clientes)
                              .Where(filial => filial.FilialId == id)
                              .ToListAsync();
        }
        public async Task<IEnumerable<Filial>> GetUsuario(int id)
        {
            return await Get().Include(x => x.Usuarios)
                              .Where(filial => filial.FilialId == id)
                              .ToListAsync();
        }



    }
}
