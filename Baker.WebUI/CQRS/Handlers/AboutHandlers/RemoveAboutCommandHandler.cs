using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.AboutCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IMongoCollection<About> _collection;

        public RemoveAboutCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }
        
        public void Handle(RemoveAboutCommand command)
        {
            var values = Builders<About>.Filter.Eq(x => x.ID, command.Id);

            _collection.DeleteOne(values);
        }
    }
}