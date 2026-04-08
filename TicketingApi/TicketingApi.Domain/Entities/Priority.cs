using TicketingApi.Domain.Common;

namespace TicketingApi.Domain.Entities
{
    public class Priority : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
    }
}
