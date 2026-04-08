using System.Data;
using Dapper;

using TicketingApi.Infrastructure.Configurations;

namespace TicketingApi.Infrastructure.Repositories
{
    public class DapperExecutor<T> 
    {
        private readonly DatabaseContext _context;

        public DapperExecutor(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> ExecuteQueryListAsync(string storedProcedure)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<T>(storedProcedure, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> ExecuteQueryListAsync(string storedProcedure, DynamicParameters parameters)
        {
            using var connection = _context.CreateConnection();

            return await connection.QueryAsync<T>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure
            );
        }

        public async Task<T> ExecuteQuerySingleAsync(string storedProcedure)
        {
            using var connection = _context.CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<T>(
                storedProcedure,
                commandType: CommandType.StoredProcedure
            );

            return await Task.FromResult(result!);
        }

        public async Task<T> ExecuteQuerySingleAsync(string storedProcedure, DynamicParameters parameters)
        {
            using var connection = _context.CreateConnection();
            var result = await connection.QueryFirstOrDefaultAsync<T>(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure
            );
            return await Task.FromResult(result!);
        }

        public async Task<bool> ExecuteNonQueryAsync(string storedProcedure)
        {
            using var connection = _context.CreateConnection();

            var affectedRows = await connection.ExecuteAsync(
                storedProcedure,
                commandType: CommandType.StoredProcedure
            );

            return affectedRows > 0;
        }

        public async Task<bool> ExecuteNonQueryAsync(string storedProcedure, DynamicParameters parameters)
        {
            using var connection = _context.CreateConnection();

            var affectedRows = await connection.ExecuteAsync(
                storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return affectedRows > 0;
        }
    }
}