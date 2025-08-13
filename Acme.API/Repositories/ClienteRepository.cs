using Acme.API.Data;
using Acme.API.Interfaces;
using Acme.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Acme.API.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AcmeDbContext _context;
        public ClienteRepository(AcmeDbContext context)
        {
            _context = context;
        }




        public async Task AddAsync(Cliente cliente)
        {
            //insere (salva) o registro no banco de dados
            await _context.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            //apaga o registro da tabela
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Cliente>> GetAllAsync()
        {
            //lista todos os registros
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetByIdAsync(int id)
        {
            //seleciona um registro por id
            return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            //atualiza o registro no banco de dados
            await _context.SaveChangesAsync();
        }
    }
}
