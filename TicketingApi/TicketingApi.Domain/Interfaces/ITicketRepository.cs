using TicketingApi.Domain.Entities;

namespace TicketingApi.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task<Ticket?> GetByIdAsync(int id);
        Task<int> CreateAsync(Ticket ticket);
        Task<bool> UpdateAsync(Ticket ticket);
        Task<bool> UpdateStatusAsync(int id, int status);
    }
}
