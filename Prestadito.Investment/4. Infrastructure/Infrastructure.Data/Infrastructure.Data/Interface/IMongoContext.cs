using MongoDB.Driver;
using Prestadito.Investment.Domain.MainModule.Entities;

namespace Prestadito.Investment.Infrastructure.Data.Interface
{
    public interface IMongoContext
    {
        IMongoCollection<FinancingEntity> Financings { get; }
    }
}
