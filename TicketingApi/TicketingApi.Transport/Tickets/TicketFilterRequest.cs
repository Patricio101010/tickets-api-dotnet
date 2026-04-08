namespace TicketingApi.Transport.Tickets
{
    public class TicketFilterRequest
    {
        public string? Search { get; set; }
        public int? Status { get; set; }
        public int? PriorityId { get; set; }
        public int? CategoryId { get; set; }
    }
}
