using CharcutariaAPI.Context;
using CharcutariaAPI.Models;
using CharcutariaAPI.Pagination;
using CharcutariaAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace CharcutariaAPI.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {            
        }

        public async Task<IEnumerable<Cliente>> GetClientePorNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
            {
                var cliente = await Get().Where(cliente => cliente.Nome.Contains(nome)).ToListAsync();
                return cliente;
            }
            else
            {
                var cliente = await Get().ToListAsync();
                return cliente;
            }
        }

        

    }
}
