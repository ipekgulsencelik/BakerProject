using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.AboutCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IMongoCollection<About> _collection;

        public UpdateAboutCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }

        public void Handle(UpdateAboutCommand command)
        {
            var values = Builders<About>.Filter.Eq(x => x.ID, command.AboutID);

            var about = Builders<About>.Update
                .Set(x => x.AboutTitle, command.AboutTitle)
                .Set(x => x.AboutSubTitle, command.AboutSubTitle)
                .Set(x => x.AboutDescription1, command.AboutDescription1)
                .Set(x => x.AboutDescription2, command.AboutDescription2)
                .Set(x => x.AboutImage1, command.AboutImage1)
                .Set(x => x.AboutImage2, command.AboutImage2)
                .Set(x => x.CreatedAt, command.CreatedAt)
                .Set(x => x.Status, command.Status);

            _collection.UpdateOne(values, about);
        }
    }
}