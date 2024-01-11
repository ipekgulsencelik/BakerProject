using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.OfferCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.OfferHandlers
{
    public class CreateOfferCommandHandler
    {
        private readonly IMongoCollection<Offer> _collection;

        public CreateOfferCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Offer>(databaseSettings.OfferCollectionName);
        }

        public void Handle(CreateOfferCommand command)
        {
            var offer = new Offer
            {
                OfferTitle = command.OfferTitle,
                OfferSubTitle = command.OfferSubTitle,
                OfferDescription = command.OfferDescription,
                OfferImage1 = command.OfferImage1,
                OfferImage2 = command.OfferImage2,
                CreatedAt = command.CreatedAt,
                Status = command.Status
            };

            _collection.InsertOne(offer);
        }
    }
}