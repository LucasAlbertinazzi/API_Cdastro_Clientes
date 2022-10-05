using Microsoft.EntityFrameworkCore;

namespace GestaoDeClientes.API.Model
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Situacao> situacaos { get; set; }
        public DbSet<Tipo> tipos { get; set; }
    }
}
