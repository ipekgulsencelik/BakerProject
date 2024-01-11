using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.OfferCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.OfferHandlers
{
    public class RemoveOfferCommandHandler
    {
        private readonly IMongoCollection<Offer> _collection;

        public RemoveOfferCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Offer>(databaseSettings.OfferCollectionName);
        }

        public void Handle(RemoveOfferCommand command)
        {
            var values = Builders<Offer>.Filter.Eq(x => x.ID, command.Id);

            _collection.DeleteOne(values);
        }
    }
}