using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.ServiceCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler
    {
        private readonly IMongoCollection<Service> _collection;

        public CreateServiceCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }

        public void Handle(CreateServiceCommand command)
        {
            var service = new Service
            {
                Icon = command.Icon,
                Title = command.Title,
                Description = command.Description,
                OfferID = command.OfferID,
                CreatedAt = command.CreatedAt,
                IsHome = command.IsHome,
                Status = command.Status
            };

            _collection.InsertOne(service);
        }
    }
}