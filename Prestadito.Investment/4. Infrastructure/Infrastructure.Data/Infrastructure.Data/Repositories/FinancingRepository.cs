using MongoDB.Driver;
using Prestadito.Investment.Domain.MainModule.Entities;
using Prestadito.Investment.Infrastructure.Data.Interface;

namespace Prestadito.Investment.Infrastructure.Data.Repositories
{
    public class FinancingRepository : IFinancingRepository
    {
        private readonly IMongoContext _context;

        public FinancingRepository(IMongoContext context)
        {
            _context = context;
        }

        public async ValueTask<FinancingEntity> GetSingleAsync(FilterDefinition<FinancingEntity> filterDefinition)
        {
            var result = await _context.Financings.FindAsync(filterDefinition);
            return await result.SingleOrDefaultAsync();
        }

        public async ValueTask<IEnumerable<FinancingEntity>> GetAsync(FilterDefinition<FinancingEntity> filterDefinition)
        {
            var result = await _context.Financings.FindAsync(filterDefinition);
            return result.ToEnumerable();
        }

        public async ValueTask InsertOneAsync(FinancingEntity entity)
        {
            await _context.Financings.InsertOneAsync(entity);
        }

        public async ValueTask<bool> UpdateOneAsync(FilterDefinition<FinancingEntity> filterDefinition, UpdateDefinition<FinancingEntity> updateDefinition)
        {
            var result = await _context.Financings.UpdateOneAsync(filterDefinition, updateDefinition);
            return result.IsAcknowledged && result.ModifiedCount == 1;
        }

        public async ValueTask<bool> DeleteOneAsync(FilterDefinition<FinancingEntity> filterDefinition)
        {
            var result = await _context.Financings.DeleteOneAsync(filterDefinition);
            return result.IsAcknowledged && result.DeletedCount == 1;
        }
    }
}
