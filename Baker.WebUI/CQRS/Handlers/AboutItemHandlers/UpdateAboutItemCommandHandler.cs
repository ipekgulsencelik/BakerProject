using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.AboutItemCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.AboutItemHandlers
{
    public class UpdateAboutItemCommandHandler
    {
        private readonly IMongoCollection<AboutItem> _collection;

        public UpdateAboutItemCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<AboutItem>(databaseSettings.AboutItemCollectionName);
        }

        public void Handle(UpdateAboutItemCommand command)
        {
            var values = Builders<AboutItem>.Filter.Eq(x => x.ID, command.ID);

            var item = Builders<AboutItem>.Update
                .Set(x => x.ItemName, command.ItemName)
                .Set(x => x.AboutID, command.AboutID)
                .Set(x => x.CreatedAt, command.CreatedAt)
                .Set(x => x.IsHome, command.IsHome)
                .Set(x => x.Status, command.Status);

            _collection.UpdateOne(values, item);
        }
    }
}