using TicketingApi.Domain.Entities;

namespace TicketingApi.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
    }
}
