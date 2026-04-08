
using TicketingApi.Domain.Common;
using TicketingApi.Domain.Enums;

namespace TicketingApi.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TicketStatus Status { get; set; } = TicketStatus.Open;
        public int PriorityId { get; set; }
        public int CategoryId { get; set; }
        public int RequesterId { get; set; }
        public int? AssignedUserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
