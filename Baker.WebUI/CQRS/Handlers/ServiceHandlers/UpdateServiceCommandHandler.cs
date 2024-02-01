using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.ServiceCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.ServiceHandlers
{
    public class UpdateServiceCommandHandler
    {
        private readonly IMongoCollection<Service> _collection;

        public UpdateServiceCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }

        public void Handle(UpdateServiceCommand command)
        {
            var values = Builders<Service>.Filter.Eq(x => x.ID, command.ID);

            var service = Builders<Service>.Update
                .Set(x => x.Icon, command.Icon)
                .Set(x => x.Title, command.Title)
                .Set(x => x.Description, command.Description)
                .Set(x => x.OfferID, command.OfferID)
                .Set(x => x.CreatedAt, command.CreatedAt)
                .Set(x => x.IsHome, command.IsHome)
                .Set(x => x.Status, command.Status);

            _collection.UpdateOne(values, service);
        }
    }
}