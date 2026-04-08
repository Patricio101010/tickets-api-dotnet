namespace TicketingApi.Transport.Common
{
    public class ResponseApi
    {
        public class ApiResponse
        {
            public ResponseInfo Response { get; set; } = new ResponseInfo();
        }

        public class ApiResponse<T>
        {
            public T Value { get; set; } = default!;
            public ResponseInfo Response { get; set; } = new ResponseInfo();
        }

        public class ApiListResponse<T>
        {
            public List<T> Items { get; set; } = new List<T>();
            public ResponseInfo Response { get; set; } = new ResponseInfo();
        }

        public class ResponseInfo
        {
            public int Code { get; set; }
            public string Message { get; set; } = string.Empty;
        }
    }
}
