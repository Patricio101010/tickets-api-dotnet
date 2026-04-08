using TicketingApi.Domain.Entities;

namespace TicketingApi.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
    }
}
