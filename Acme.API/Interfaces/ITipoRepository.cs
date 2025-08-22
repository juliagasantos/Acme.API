using Acme.API.Models;

namespace Acme.API.Interfaces
{
    public interface ITipoRepository 
    {
        Task<List<Tipo>> GetAllAsync();
        Task<Tipo?> GetByIdAsync(int id);
        Task AddAsync(Tipo tipo);
        Task UpdateAsync(Tipo tipo);
        Task DeleteAsync(int id);
    }
}
