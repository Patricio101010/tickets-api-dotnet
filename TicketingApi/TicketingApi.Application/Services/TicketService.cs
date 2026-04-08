using Dapper;
using TicketingApi.Application.Interfaces;
using TicketingApi.Domain.Entities;
using TicketingApi.Infrastructure.Configurations;
using TicketingApi.Infrastructure.Repositories;
using TicketingApi.Transport.Tickets;

namespace TicketingApi.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly DatabaseContext _context;

        public TicketService(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Maps a Ticket entity to a TicketResponse DTO.
        /// </summary>
        /// <param name="ticket">The Ticket entity to map.</param>
        /// <returns>A TicketResponse DTO.</returns>
        private static TicketResponse MapToResponse(Ticket ticket)
        {
            return new TicketResponse
            {
                Id = ticket.Id,
                Code = ticket.Code,
                Title = ticket.Title,
                Description = ticket.Description,
                Status = ticket.Status.ToString(),
                Priority = ticket.PriorityId.ToString(),
                Category = ticket.CategoryId.ToString(),
                RequesterId = ticket.RequesterId,
                AssignedUserId = ticket.AssignedUserId,
                CreatedAt = ticket.CreatedAt,
                UpdatedAt = ticket.UpdatedAt
            };
        }

        private static string GenerateCode()
        {
            return $"TCK-{DateTime.UtcNow:yyyyMMddHHmmss}";
        }

        public async Task<List<TicketResponse>> GetAllAsync(TicketFilterRequest filter)
        {
            var dal = new DapperExecutor<Ticket>(_context);

            //parametros Procedimiento almacenado - sql server
            var parametros = new DynamicParameters();
            parametros.Add("@", filter.PriorityId);
            var resultadoDAL = dal.ExecuteQueryListAsync("", parametros);

            // Convertir resultado a lista de respuestas
            var tickets = (await resultadoDAL).ToList();
            var listado = tickets.Select(MapToResponse).ToList();

            // Retornar respuesta paginada
            return listado;
        }

        public async Task<TicketResponse> GetByIdAsync(int id)
        {
            var dal = new DapperExecutor<Ticket>(_context);

            //parametros Procedimiento almacenado - sql server
            var parametros = new DynamicParameters();
            parametros.Add("@", id);
            var resultadoDAL = dal.ExecuteQuerySingleAsync("", parametros);

            var ticket = await resultadoDAL;

            if (ticket is null)
                return new TicketResponse();

            return MapToResponse(ticket);
        }

        public async Task<bool> CreateAsync(TicketCreateRequest request)
        {
            var dal = new DapperExecutor<object>(_context);
            //parametros Procedimiento almacenado - sql server
            var parametros = new DynamicParameters();
            parametros.Add("@", GenerateCode());
            //Code = GenerateCode(),
            //Title = request.Title.Trim(),
            //Description = request.Description.Trim(),
            //Status = TicketStatus.Open,
            //PriorityId = request.PriorityId,
            //CategoryId = request.CategoryId,
            //RequesterId = request.RequesterId,
            //CreatedAt = DateTime.UtcNow

            var resultado = dal.ExecuteNonQueryAsync("", parametros);

            return await resultado;
        }

        public async Task<bool> UpdateAsync(int id, TicketUpdateRequest request)
        {
            var ticket = await GetByIdAsync(id);

            if (ticket is null)
                return false;

            //ticket.Title = request.Title.Trim();
            //ticket.Description = request.Description.Trim();
            //ticket.PriorityId = request.PriorityId;
            //ticket.CategoryId = request.CategoryId;
            //ticket.AssignedUserId = request.AssignedUserId;
            //ticket.UpdatedAt = DateTime.UtcNow;

            var dal = new DapperExecutor<object>(_context);
            //parametros Procedimiento almacenado - sql server
            var parametros = new DynamicParameters();
            parametros.Add("@", GenerateCode());
            //Code = GenerateCode(),
            //Title = request.Title.Trim(),
            //Description = request.Description.Trim(),
            //Status = TicketStatus.Open,
            //PriorityId = request.PriorityId,
            //CategoryId = request.CategoryId,
            //RequesterId = request.RequesterId,
            //CreatedAt = DateTime.UtcNow

            var resultado = dal.ExecuteNonQueryAsync("", parametros);
            return await resultado;
        }

        public async Task<bool> UpdateStatusAsync(int id, TicketStatusUpdateRequest request)
        {
            var dal = new DapperExecutor<object>(_context);
            //parametros Procedimiento almacenado - sql server
            var parametros = new DynamicParameters();
            parametros.Add("@StatusId", id);
            parametros.Add("@", id);


            var resultado = dal.ExecuteNonQueryAsync("", parametros);
            return await resultado;

        }
    }
}