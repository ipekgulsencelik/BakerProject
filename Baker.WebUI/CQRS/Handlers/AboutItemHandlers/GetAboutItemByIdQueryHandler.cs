using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Queries.AboutItemQueries;
using Baker.WebUI.CQRS.Results.AboutItemResults;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.AboutItemHandlers
{
    public class GetAboutItemByIdQueryHandler
    {
        private readonly IMongoCollection<AboutItem> _collection;

        public GetAboutItemByIdQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<AboutItem>(databaseSettings.AboutItemCollectionName);
        }

        public GetAboutItemByIdQueryResult Handle(GetAboutItemByIdQuery query)
        {
            var values = Builders<AboutItem>.Filter.Eq(x => x.ID, query.Id);

            var item = _collection.Find(values).FirstOrDefault();

            var result = new GetAboutItemByIdQueryResult
            {
                ID = item.ID,
                ItemName = item.ItemName,                
                AboutID = item.AboutID,
                CreatedAt = item.CreatedAt,
                IsHome = item.IsHome,
                Status = item.Status
            };

            return result;
        }
    }
}