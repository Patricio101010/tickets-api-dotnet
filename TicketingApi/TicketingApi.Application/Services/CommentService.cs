
using Dapper;
using TicketingApi.Application.Interfaces;
using TicketingApi.Domain.Entities;
using TicketingApi.Infrastructure.Configurations;
using TicketingApi.Infrastructure.Repositories;
using TicketingApi.Transport.Comments;
using TicketingApi.Transport.Tickets;

namespace TicketingApi.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly ITicketService _ticketService;
        private readonly DatabaseContext _context;

        public CommentService(
            DatabaseContext context,
            ITicketService ticketService)
        {
            _context = context;
            _ticketService = ticketService;
        }

        public async Task<bool> CreateAsync(int ticketId, CommentCreateRequest request)
        {
            var ticket = await _ticketService.GetByIdAsync(ticketId);

            if (ticket is null)
                return false;

            //var comment = new Comment
            //{
            //    TicketId = ticketId,
            //    UserId = request.UserId,
            //    Message = request.Message.Trim(),
            //    CreatedAt = DateTime.UtcNow
            //};


            var dal = new DapperExecutor<Ticket>(_context);

            //parametros Procedimiento almacenado - sql server
            var parametros = new DynamicParameters();
            parametros.Add("@", ticketId);

            var resultadoDAL = dal.ExecuteNonQueryAsync("", parametros);

            return await resultadoDAL;
        }


    }
}