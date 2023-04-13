using MongoDB.Driver;
using Prestadito.Investment.Domain.MainModule.Entities;

namespace Prestadito.Investment.Application.Manager.QueryBuilder.FilterDefinition
{
    public static class FinancingFilterDefinition
    {
        public static FilterDefinition<FinancingEntity> FindFinancingById(string financingId)
        {
            var filter = Builders<FinancingEntity>.Filter.Eq(s => s.Id, financingId);
            return filter;
        }

        public static FilterDefinition<FinancingEntity> FindAllFinancings()
        {
            var filter = Builders<FinancingEntity>.Filter.Empty;
            return filter;
        }

        public static FilterDefinition<FinancingEntity> FindFinancingsActive()
        {
            var filter = Builders<FinancingEntity>.Filter.Eq(s => s.BlnActive, true);
            return filter;
        }
    }
}
