using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Queries.ServiceQueries;
using Baker.WebUI.CQRS.Results.ServiceResults;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.ServiceHandlers
{
    public class GetServiceByIdQueryHandler
    {
        private readonly IMongoCollection<Service> _collection;

        public GetServiceByIdQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }

        public GetServiceByIdQueryResult Handle(GetServiceByIdQuery query)
        {
            var values = Builders<Service>.Filter.Eq(x => x.ID, query.Id);

            var service = _collection.Find(values).FirstOrDefault();

            var result = new GetServiceByIdQueryResult
            {
                ServiceID = service.ID,
                Icon = service.Icon,
                Title = service.Title,
                Description = service.Description,
                OfferID = service.OfferID,
                CreatedAt = service.CreatedAt,
                IsHome = service.IsHome,
                Status = service.Status
            };

            return result;
        }
    }
}