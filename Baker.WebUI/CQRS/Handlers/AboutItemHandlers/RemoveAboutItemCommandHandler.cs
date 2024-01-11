using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.AboutItemCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.AboutItemHandlers
{
    public class RemoveAboutItemCommandHandler
    {
        private readonly IMongoCollection<AboutItem> _collection;

        public RemoveAboutItemCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<AboutItem>(databaseSettings.AboutItemCollectionName);
        }

        public void Handle(RemoveAboutItemCommand command)
        {
            var values = Builders<AboutItem>.Filter.Eq(x => x.ID, command.Id);

            _collection.DeleteOne(values);
        }
    }
}