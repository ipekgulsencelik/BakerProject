using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Results.ServiceResults;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler
    {
        private readonly IMongoCollection<Service> _collection;

        public GetServiceQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }

        public List<GetServiceQueryResult> Handle()
        {
            var values = _collection.Find(FilterDefinition<Service>.Empty).ToList();

            var result = values.Select(item => new GetServiceQueryResult
            {
                ServiceID = item.ID,
                Description = item.Description,
                Icon = item.Icon,
                Title = item.Title,               
                OfferID = item.OfferID,
                CreatedAt = item.CreatedAt,
                IsHome = item.IsHome,
                Status = item.Status
            }).ToList();

            return result;
        }
    }
}