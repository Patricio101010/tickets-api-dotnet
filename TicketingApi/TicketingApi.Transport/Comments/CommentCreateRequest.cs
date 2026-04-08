namespace TicketingApi.Transport.Comments
{
    public class CommentCreateRequest
    {
        public int UserId { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}
