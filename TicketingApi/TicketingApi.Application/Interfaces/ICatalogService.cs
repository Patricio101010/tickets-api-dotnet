using TicketingApi.Transport.Common;

namespace TicketingApi.Application.Interfaces
{
    public interface ICatalogService
    {

        Task<List<CatalogResponse>> GetCategoriesAsync();
        Task<List<CatalogResponse>> GetPrioritiesAsync();
        Task<List<CatalogResponse>> GetUsersAsync();

    }
}
