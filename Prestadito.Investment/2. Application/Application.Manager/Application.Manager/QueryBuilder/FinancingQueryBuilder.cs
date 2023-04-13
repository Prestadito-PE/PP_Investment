using MongoDB.Driver;
using Prestadito.Investment.Application.Manager.QueryBuilder.FilterDefinition;
using Prestadito.Investment.Application.Manager.QueryBuilder.UpdateDefinition;
using Prestadito.Investment.Domain.MainModule.Entities;

namespace Prestadito.Investment.Application.Manager.QueryBuilder
{
    public static class FinancingQueryBuilder
    {
        public static Tuple<FilterDefinition<FinancingEntity>, UpdateDefinition<FinancingEntity>> UpdateFinancingDisable(string financingId)
        {
            var filterDefinition = FinancingFilterDefinition.FindFinancingById(financingId);
            var updateDefinition = FinancingUpdateDefinition.Disable();

            return Tuple.Create(filterDefinition, updateDefinition);
        }

        public static FilterDefinition<FinancingEntity> FindAllFinancings()
        {
            var query = FinancingFilterDefinition.FindAllFinancings();
            return query;
        }

        public static FilterDefinition<FinancingEntity> FindFinancingsActive()
        {
            var query = FinancingFilterDefinition.FindFinancingsActive();
            return query;
        }

        public static FilterDefinition<FinancingEntity> FindFinancingById(string financingId)
        {
            var query = FinancingFilterDefinition.FindFinancingById(financingId);
            return query;
        }

        public static UpdateDefinition<FinancingEntity> UpdateFinancing(FinancingEntity entity)
        {
            var updateDefinition = FinancingUpdateDefinition.UpdateFinancing(entity);
            return updateDefinition;
        }
    }
}
