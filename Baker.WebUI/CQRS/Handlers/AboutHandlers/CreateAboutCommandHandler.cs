using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.AboutCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.AboutHandlers
{
    public class CreateAboutCommandHandler
    {
        private readonly IMongoCollection<About> _collection;

        public CreateAboutCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }

        public void Handle(CreateAboutCommand command)
        {
            var about = new About
            {
                AboutTitle = command.AboutTitle,
                AboutSubTitle = command.AboutSubTitle,
                AboutDescription1 = command.AboutDescription1,
                AboutDescription2 = command.AboutDescription2,
                AboutImage1 = command.AboutImage1,
                AboutImage2 = command.AboutImage2,
                CreatedAt = command.CreatedAt,
                Status = command.Status
            };

            _collection.InsertOne(about);
        }
    }
}