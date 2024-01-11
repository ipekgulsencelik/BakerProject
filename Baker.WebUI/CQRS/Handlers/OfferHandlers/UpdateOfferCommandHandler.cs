using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.OfferCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.OfferHandlers
{
    public class UpdateOfferCommandHandler
    {
        private readonly IMongoCollection<Offer> _collection;

        public UpdateOfferCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Offer>(databaseSettings.OfferCollectionName);
        }

        public void Handle(UpdateOfferCommand command)
        {
            var values = Builders<Offer>.Filter.Eq(x => x.ID, command.OfferID);

            var offer  = Builders<Offer>.Update
                .Set(x => x.OfferTitle, command.OfferTitle)
                .Set(x => x.OfferSubTitle, command.OfferSubTitle)
                .Set(x => x.OfferDescription, command.OfferDescription)
                .Set(x => x.OfferImage1, command.OfferImage1)
                .Set(x => x.OfferImage2, command.OfferImage2)
                .Set(x => x.CreatedAt, command.CreatedAt)
                .Set(x => x.Status, command.Status);

            _collection.UpdateOne(values, offer);
        }
    }
}