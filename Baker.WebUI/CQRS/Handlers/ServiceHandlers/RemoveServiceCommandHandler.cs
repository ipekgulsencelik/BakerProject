using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.ServiceCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.ServiceHandlers
{
    public class RemoveServiceCommandHandler
    {
        private readonly IMongoCollection<Service> _collection;

        public RemoveServiceCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }

        public void Handle(RemoveServiceCommand command)
        {
            var values = Builders<Service>.Filter.Eq(x => x.ID, command.Id);

            _collection.DeleteOne(values);
        }
    }
}