using GestaoDeClientes.API.Model;

namespace GestaoDeClientes.API.Repositories
{
    public interface IGestaoRepository
    {
        Task<IEnumerable<Cliente>> Get();

        Task<CadastroFull> Get(int id);

        Task<Cliente> Create(Cliente cliente);

        Task Update(Cliente cliente);

        Task Delete(int id);
    }
}
