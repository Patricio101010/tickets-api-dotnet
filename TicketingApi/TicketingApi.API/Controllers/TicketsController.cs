using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketingApi.Application.Interfaces;
using TicketingApi.Transport.Common;
using TicketingApi.Transport.Tickets;
using static TicketingApi.Transport.Common.ResponseApi;

namespace TicketingApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /// <summary>
        /// Obtener lista de tickets (con filtros y paginación)
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] TicketFilterRequest filter)
        {
            var getDto = new ApiListResponse<TicketResponse>();
            var response = new ResponseInfo();
            try
            {
                var result = await _ticketService.GetAllAsync(filter);
                if (!result.Any())
                {
                    response = new ResponseInfo { Code = 1, Message = "No tickets found." };
                    getDto.Response = response;
                    return NotFound(getDto);
                }

                response = new ResponseInfo { Code = 0, Message = "Tickets retrieved successfully." };
                getDto.Response = response;
                getDto.Items = result;

                return Ok(getDto);
            }
            catch (Exception ex)
            {

                response = new ResponseInfo { Code = 2, Message = ex.Message };
                getDto.Response = response;

                return StatusCode(StatusCodes.Status500InternalServerError, getDto);
            }
        }

        /// <summary>
        /// Obtener ticket por id
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var getDto = new ApiResponse<TicketResponse>();
            var response = new ResponseInfo();
            try
            {
                var result = await _ticketService.GetByIdAsync(id);
                if (result is null)
                {
                    response = new ResponseInfo { Code = 1, Message = "Ticket not found." };
                    getDto.Response = response;
                    return NotFound(getDto);
                }

                response = new ResponseInfo { Code = 0, Message = "Ticket retrieved successfully." };
                getDto.Response = response;
                getDto.Value = result;

                return Ok(getDto);
            }
            catch (Exception ex)
            {

                response = new ResponseInfo { Code = 2, Message = ex.Message };
                getDto.Response = response;

                return StatusCode(StatusCodes.Status500InternalServerError, getDto);
            }
        }

        /// <summary>
        /// Crear ticket
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TicketCreateRequest request)
        {
            var getDto = new ApiResponse();
            var response = new ResponseInfo();
            try
            {
                var result = await _ticketService.CreateAsync(request);
                if (!result)
                {
                    response = new ResponseInfo { Code = 1, Message = "Failed to create ticket." };
                    getDto.Response = response;
                    return BadRequest(getDto);
                }

                getDto.Response = new ResponseInfo { Code = 0, Message = "Ticket created successfully." };

                return Ok(getDto);
            }
            catch (Exception ex)
            {

                response = new ResponseInfo
                {
                    Code = 2,
                    Message = ex.Message
                };
                getDto.Response = response;

                return StatusCode(StatusCodes.Status500InternalServerError, getDto);
            }
        }

        /// <summary>
        /// Actualizar ticket
        /// </summary>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] TicketUpdateRequest request)
        {
            var getDto = new ApiListResponse<TicketResponse>();
            var response = new ResponseInfo();
            try
            {
                var updated = await _ticketService.UpdateAsync(id, request);
                if (!updated)
                { 
                    response = new ResponseInfo { Code = 1, Message = "Ticket not found." };
                    getDto.Response = response;
                    return NotFound(getDto);
                }


                response = new ResponseInfo { Code =0, Message = "Ticket updated successfully." };
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

        /// <summary>
        /// Actualizar estado del ticket
        /// </summary>
        [HttpPatch("{id:int}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] TicketStatusUpdateRequest request)
        {
            var getDto = new ApiListResponse<TicketResponse>();
            var response = new ResponseInfo();
            try
            {
                var updated = await _ticketService.UpdateStatusAsync(id, request);

                if (!updated)
                {
                    response = new ResponseInfo { Code = 1, Message = "Ticket not found or invalid status." };
                    getDto.Response = response;
                    return NotFound(getDto);        
                }

                response = new ResponseInfo { Code = 0, Message = "Ticket updated successfully." };
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