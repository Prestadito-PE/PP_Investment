using MongoDB.Driver;
using Prestadito.Investment.Domain.MainModule.Entities;

namespace Prestadito.Investment.Application.Manager.QueryBuilder.UpdateDefinition
{
    public static class FinancingUpdateDefinition
    {
        public static UpdateDefinition<FinancingEntity> Disable()
        {
            var update = Builders<FinancingEntity>.Update.Set(u => u.BlnActive, false);
            return update;
        }

        public static UpdateDefinition<FinancingEntity> UpdateFinancing(FinancingEntity entity)
        {
            var update = Builders<FinancingEntity>.Update
                .Set(u => u.BlnActive, entity.BlnActive)
                .Set(u => u.DteUpdatedAt, entity.DteUpdatedAt)
                .Set(u => u.StrUpdateUser, entity.StrUpdateUser);
            return update;
        }
    }
}
