using Acme.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Acme.API.Data
{
    public class AcmeDbContext : DbContext
    {
        public AcmeDbContext(DbContextOptions<AcmeDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
    }
}
