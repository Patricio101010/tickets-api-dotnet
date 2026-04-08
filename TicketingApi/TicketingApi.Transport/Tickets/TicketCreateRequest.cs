namespace TicketingApi.Transport.Tickets
{
    public class TicketCreateRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PriorityId { get; set; }
        public int CategoryId { get; set; }
        public int RequesterId { get; set; }
    }
}
