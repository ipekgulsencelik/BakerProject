using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.AboutItemCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.AboutItemHandlers
{
    public class CreateAboutItemCommandHandler
    {
        private readonly IMongoCollection<AboutItem> _collection;

        public CreateAboutItemCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<AboutItem>(databaseSettings.AboutItemCollectionName);
        }

        public void Handle(CreateAboutItemCommand command)
        {
            var item = new AboutItem
            {
                ItemName = command.ItemName,
                AboutID = command.AboutID,
                CreatedAt = command.CreatedAt,
                IsHome = command.IsHome,
                Status = command.Status
            };

            _collection.InsertOne(item);
        }
    }
}