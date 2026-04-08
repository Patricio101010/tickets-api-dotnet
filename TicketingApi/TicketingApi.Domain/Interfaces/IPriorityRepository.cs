using TicketingApi.Domain.Entities;

namespace TicketingApi.Domain.Interfaces
{
    public interface IPriorityRepository
    {
        Task<IEnumerable<Priority>> GetAllAsync();
        Task<Priority?> GetByIdAsync(int id);
    }
}
