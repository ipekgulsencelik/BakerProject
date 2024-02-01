using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.ServiceCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.ServiceHandlers
{
    public class ChangeServiceStatusCommandHandler
    {
        private readonly IMongoCollection<Service> _collection;

        public ChangeServiceStatusCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Service>(databaseSettings.ServiceCollectionName);
        }

        public void Handle(ChangeServiceStatusCommand command)
        {
            var value = Builders<Service>.Filter.Eq(x => x.ID, command.ServiceID);

            var status = true;
            if (command.Status == true)
                status = false;
            else if (command.Status == false)
                status = true;

            var service = Builders<Service>.Update
                .Set(x => x.Status, command.Status);

            _collection.UpdateOne(value, service);
        }
    }
}