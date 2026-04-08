using TicketingApi.Transport.Common;
using TicketingApi.Transport.Tickets;

namespace TicketingApi.Application.Interfaces
{
    public interface ITicketService
    {
        Task<List<TicketResponse>> GetAllAsync(TicketFilterRequest filter);
        Task<bool> CreateAsync(TicketCreateRequest request);
        Task<bool> UpdateAsync(int id, TicketUpdateRequest request);
        Task<bool> UpdateStatusAsync(int id, TicketStatusUpdateRequest request);
        Task<TicketResponse> GetByIdAsync(int id);
    }
}
