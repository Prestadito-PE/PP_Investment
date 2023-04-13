using MongoDB.Driver;
using Prestadito.Investment.Domain.MainModule.Entities;

namespace Prestadito.Investment.Infrastructure.Data.Interface
{
    public interface IFinancingRepository
    {
        ValueTask<FinancingEntity> GetSingleAsync(FilterDefinition<FinancingEntity> filterDefinition);
        ValueTask<IEnumerable<FinancingEntity>> GetAsync(FilterDefinition<FinancingEntity> filterDefinition);
        ValueTask InsertOneAsync(FinancingEntity entity);
        ValueTask<bool> UpdateOneAsync(FilterDefinition<FinancingEntity> filterDefinition, UpdateDefinition<FinancingEntity> updateDefinition);
        ValueTask<bool> DeleteOneAsync(FilterDefinition<FinancingEntity> filterDefinition);
    }
}
