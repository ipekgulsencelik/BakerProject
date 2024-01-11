using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Results.AboutItemResults;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.AboutItemHandlers
{
    public class GetAboutItemQueryHandler
    {
        private readonly IMongoCollection<AboutItem> _collection;

        public GetAboutItemQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<AboutItem>(databaseSettings.AboutItemCollectionName);
        }

        public List<GetAboutItemQueryResult> Handle()
        {
            var values = _collection.Find(FilterDefinition<AboutItem>.Empty).ToList();

            var result = values.Select(item => new GetAboutItemQueryResult
            {
                AboutItemID = item.ID,
                ItemName = item.ItemName,
                AboutID = item.AboutID,
                CreatedAt = item.CreatedAt,
                IsHome = item.IsHome,
                Status = item.Status
            }).ToList();

            return result;
        }
    }
}