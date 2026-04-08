using TicketingApi.Transport.Comments;

namespace TicketingApi.Application.Interfaces
{
    public interface ICommentService
    {
        Task<bool> CreateAsync(int ticketId, CommentCreateRequest request);
    }
}
