using MongoDB.Driver;

namespace Prestadito.Investment.Infrastructure.Data.Utilities
{
    public static class SortDefinition
    {
        public static FindOptions<T> BuildFindOptions<T>() where T : class
        {
            FindOptions<T> findOptions = new FindOptions<T>();

            return findOptions;
        }
    }
}
