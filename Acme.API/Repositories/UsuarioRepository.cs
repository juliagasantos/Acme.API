using Acme.API.Data;
using Acme.API.Interfaces;
using Acme.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Acme.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AcmeDbContext _context;
        public UsuarioRepository(AcmeDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Usuario?> GetByLoginAsync(string email, string senha)
        {
            // seleciona um registro por email e senha
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
