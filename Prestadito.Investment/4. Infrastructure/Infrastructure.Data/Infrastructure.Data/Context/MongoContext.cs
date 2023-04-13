using MongoDB.Driver;
using Prestadito.Investment.Domain.MainModule.Entities;
using Prestadito.Investment.Infrastructure.Data.Interface;
using Prestadito.Investment.Infrastructure.Data.Utilities;

namespace Prestadito.Investment.Infrastructure.Data.Context
{
    public class MongoContext : IMongoContext
    {
        private readonly IMongoDatabase database;

        public MongoContext(IInvestmentDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionURI);
            database = client.GetDatabase(settings.DatabaseName);
        }

        public IMongoCollection<FinancingEntity> Financings
        {
            get
            {
                return database.GetCollection<FinancingEntity>(CollectionsName.colFinancings);
            }
        }

    }
}
