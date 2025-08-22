using Acme.API.Data;
using Acme.API.Interfaces;
using Acme.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Acme.API.Repositories
{
    public class TipoRepository : ITipoRepository
    {
        private readonly AcmeDbContext _context;
        public TipoRepository(AcmeDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Tipo tipo)
        {
            //insere (salva) o registro no banco de dados
            await _context.AddAsync(tipo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            //apaga o registro da tabela
            var tipo = await _context.Tipos.FindAsync(id);
            if (tipo != null)
            {
                _context.Tipos.Remove(tipo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Tipo>> GetAllAsync()
        {
            //lista todos os registros
            return await _context.Tipos.ToListAsync();
        }

        public async Task<Tipo> GetByIdAsync(int id)
        {
            //seleciona um registro por id
            return await _context.Tipos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Tipo tipo)
        {
            //atualiza o registro no banco de dados
            _context.Tipos.Update(tipo);
            await _context.SaveChangesAsync();
        }
    }
}
