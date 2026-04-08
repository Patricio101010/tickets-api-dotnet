using Microsoft.AspNetCore.Mvc;
using TicketingApi.Application.Interfaces;
using TicketingApi.Transport.Common;
using static TicketingApi.Transport.Common.ResponseApi;

namespace TicketingApi.Api.Controllers
{
    [ApiController]
    [Route("api/catalogs")]
    public class CatalogsController : ControllerBase
    {
        private readonly ICatalogService _catalogService;

        public CatalogsController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var getDto = new ApiListResponse<CatalogResponse>();
            var response = new ResponseInfo();
            try
            {
                var result = await _catalogService.GetCategoriesAsync();
                if (!result.Any())
                {
                    response = new ResponseInfo { Code = 1, Message = "No categories found." };
                    getDto.Response = response;
                    return NotFound(getDto);
                }

                response = new ResponseInfo { Code = 0, Message = "Categories retrieved successfully." };
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

        [HttpGet("priorities")]
        public async Task<IActionResult> GetPriorities()
        {
            var getDto = new ApiListResponse<CatalogResponse>();
            var response = new ResponseInfo();
            try
            {
                var result = await _catalogService.GetPrioritiesAsync();
                if (!result.Any())
                {
                    response = new ResponseInfo { Code = 1, Message = "No priorities found." };
                    getDto.Response = response;
                    return NotFound(getDto);
                }

                response = new ResponseInfo { Code = 0, Message = "Priorities retrieved successfully." };
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

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var getDto = new ApiListResponse<CatalogResponse>();
            var response = new ResponseInfo();
            try
            {
                var result = await _catalogService.GetUsersAsync();
                if (!result.Any())
                {
                    response = new ResponseInfo { Code = 1, Message = "No users found." };
                    getDto.Response = response;
                    return NotFound(getDto);
                }

                response = new ResponseInfo { Code = 0, Message = "Users retrieved successfully." };
                getDto.Response = response;
                getDto.Items = result;

                return Ok(result);
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
    }
}