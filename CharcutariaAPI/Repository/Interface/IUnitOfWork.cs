namespace CharcutariaAPI.Repository.Interface
{
    public interface IUnitOfWork
    {
        IUsuarioRepository UsuarioRepository { get; }
        IFilialRepository FilialRepository { get; }
        IClienteRepository ClienteRepository { get; }
        Task Commit();
        void Dispose();
    }
}
