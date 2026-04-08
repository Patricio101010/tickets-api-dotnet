using Microsoft.AspNetCore.Mvc;
using TicketingApi.Application.Interfaces;
using TicketingApi.Transport.Comments;
using static TicketingApi.Transport.Common.ResponseApi;

namespace TicketingApi.Api.Controllers
{
    [ApiController]
    [Route("api/tickets/{ticketId:int}/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly ITicketService _ticketService;

        public CommentsController(ICommentService commentService, ITicketService ticketService)
        {
            _commentService = commentService;
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(int ticketId, [FromBody] CommentCreateRequest request)
        {
            var getDto = new ApiResponse();
            var response = new ResponseInfo();
            try
            {
                var ticketExists = await _ticketService.GetByIdAsync(ticketId);
                if (ticketExists.Id == 0)
                {
                    response = new ResponseInfo { Code = 1, Message = "Ticket not exists." };
                    getDto.Response = response;

                    return BadRequest(getDto);
                }

                var resultado = await _commentService.CreateAsync(ticketId, request);
                if (resultado)
                {
                    response = new ResponseInfo { Code = 1, Message = "Comment not created successfully." };
                    getDto.Response = response;

                    return NotFound(getDto);
                }

                response = new ResponseInfo { Code = 0, Message = "Comment created successfully." };
                getDto.Response = response;

                return Ok(getDto);
            }
            catch (Exception ex)
            {
                response = new ResponseInfo { Code = 2, Message = ex.Message };
                getDto.Response = response;

                return StatusCode(StatusCodes.Status500InternalServerError, getDto);
            }
        }
    }
}