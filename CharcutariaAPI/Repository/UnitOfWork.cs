using CharcutariaAPI.Context;
using CharcutariaAPI.Repository.Interface;

namespace CharcutariaAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ClienteRepository _clienteRepository;

        private FilialRepository _filialRepository;

        private UsuarioRepository _usuarioRepository;

        public AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        
        public IClienteRepository ClienteRepository
        {
            get
            {
                return _clienteRepository = _clienteRepository ?? new ClienteRepository(_context);
            }
        }
        
        public IFilialRepository FilialRepository
        {
            get
            {
                return _filialRepository = _filialRepository ?? new FilialRepository(_context);
            }
        }

        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                return _usuarioRepository = _usuarioRepository ?? new UsuarioRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
