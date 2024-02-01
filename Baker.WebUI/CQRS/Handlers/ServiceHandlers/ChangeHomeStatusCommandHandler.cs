using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.ServiceCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.ServiceHandlers
{
    public class ChangeHomeStatusCommandHandler
    {
        private readonly IMongoCollection<Service> _collection;

        public ChangeHomeStatusCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }

        public void Handle(ChangeHomeStatusCommand command)
        {
            var value = Builders<Service>.Filter.Eq(x => x.ID, command.Id);

            var status = true;
            if (command.IsHome == true)
                status = false;
            else if (command.IsHome == false)
                status = true;

            var service = Builders<Service>.Update
                .Set(x => x.IsHome, command.IsHome);

            _collection.UpdateOne(value, service);
        }
    }
}