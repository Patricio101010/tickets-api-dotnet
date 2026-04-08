using TicketingApi.Domain.Entities;

namespace TicketingApi.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task<IEnumerable<Comment>> GetByTicketIdAsync(int ticketId);
        Task<int> CreateAsync(Comment comment);
    }
}
