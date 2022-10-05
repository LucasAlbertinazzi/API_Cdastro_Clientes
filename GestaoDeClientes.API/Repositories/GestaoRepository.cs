using GestaoDeClientes.API.Model;
using Microsoft.EntityFrameworkCore;

namespace GestaoDeClientes.API.Repositories
{
    public class GestaoRepository : IGestaoRepository
    {
        public readonly dbContext _dbContext;
        public GestaoRepository(dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Cliente> Create(Cliente cliente)
        {
            _dbContext.clientes.Add(cliente);
            await _dbContext.SaveChangesAsync();

            return cliente;
        }

        public async Task Delete(int id)
        {
            var clienteDelete = await _dbContext.clientes.FindAsync(id);
            _dbContext.clientes.Remove(clienteDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _dbContext.clientes.ToListAsync();
        }

        public async Task<CadastroFull> Get(int id)
        {
            var cliente = await _dbContext.clientes.FindAsync(id);
            var tipo = await _dbContext.tipos.Where(x => x.ID == cliente.tipo).ToListAsync();
            var situacao = await _dbContext.situacaos.Where(x => x.ID == cliente.situacao).ToListAsync();

            CadastroFull cadastroFull = new CadastroFull();

            cadastroFull.nome = cliente.nome;
            cadastroFull.cpf = cliente.cpf;
            cadastroFull.sexo = cliente.sexo;
            cadastroFull.situacao = situacao[0].situacao;
            cadastroFull.tipo = tipo[0].tipo;

            return cadastroFull;
        }

        public async Task Update(Cliente cliente)
        {
            _dbContext.Entry(cliente).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
