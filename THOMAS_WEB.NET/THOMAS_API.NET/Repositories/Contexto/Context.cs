using Microsoft.EntityFrameworkCore;

namespace THOMAS_API.NET.Repositories.Contexto
{
    public class Context : DbContext
    {
        public DbSet<Entities.Cliente> tblCliente { get; set; }
        public DbSet<Entities.Endereco> tblEndereco { get; set; }

        public Context(DbContextOptions<Context> options)
        : base(options)
        {
        }
    }
}
