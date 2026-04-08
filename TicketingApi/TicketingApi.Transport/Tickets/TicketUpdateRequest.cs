namespace TicketingApi.Transport.Tickets
{
    public class TicketUpdateRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int PriorityId { get; set; }
        public int CategoryId { get; set; }
        public int? AssignedUserId { get; set; }
    }
}
