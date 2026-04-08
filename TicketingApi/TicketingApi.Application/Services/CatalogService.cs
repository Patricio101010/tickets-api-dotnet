using Dapper;
using TicketingApi.Application.Interfaces;
using TicketingApi.Domain.Entities;
using TicketingApi.Infrastructure.Configurations;
using TicketingApi.Infrastructure.Repositories;
using TicketingApi.Transport.Common;

namespace TicketingApi.Application.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly DatabaseContext _context;

        public CatalogService(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<List<CatalogResponse>> GetCategoriesAsync()
        {
            var dal = new DapperExecutor<Category>(_context);

            //parametros Procedimiento almacenado - sql server
            var parametros = new DynamicParameters();
            var resultadoDAL = await dal.ExecuteQueryListAsync("", parametros);

            var catalogResponses = resultadoDAL.Select(x => new CatalogResponse
            {
                Id = x.Id,
                Values = x.Name
            }).ToList();

            return catalogResponses;
        }

        public async Task<List<CatalogResponse>> GetPrioritiesAsync()
        {
            var dal = new DapperExecutor<Category>(_context);

            //parametros Procedimiento almacenado - sql server
            var parametros = new DynamicParameters();
            var resultadoDAL = await dal.ExecuteQueryListAsync("", parametros);

            var catalogResponses = resultadoDAL.Select(x => new CatalogResponse
            {
                Id = x.Id,
                Values = x.Name
            }).ToList();

            return catalogResponses;
        }

        public async Task<List<CatalogResponse>> GetUsersAsync()
        {
            var dal = new DapperExecutor<Category>(_context);

            //parametros Procedimiento almacenado - sql server
            var parametros = new DynamicParameters();
            var resultadoDAL = await dal.ExecuteQueryListAsync("", parametros);

            var catalogResponses = resultadoDAL.Select(x => new CatalogResponse
            {
                Id = x.Id,
                Values = x.Name
            }).ToList();

            return catalogResponses;
        }
    }
}
