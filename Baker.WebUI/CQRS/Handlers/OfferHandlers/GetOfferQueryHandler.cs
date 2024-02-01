using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Results.AboutResults;
using Baker.WebUI.CQRS.Results.OfferResults;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.OfferHandlers
{
    public class GetOfferQueryHandler
    {
        private readonly IMongoCollection<Offer> _collection;

        public GetOfferQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Offer>(databaseSettings.OfferCollectionName);
        }

        public GetOfferQueryResult Handle()
        {
            var offer = _collection.Find(FilterDefinition<Offer>.Empty).FirstOrDefault();

            if (offer == null)
            {
                return new GetOfferQueryResult();
            }

            var result = new GetOfferQueryResult
            {
                OfferID = offer.ID,
                OfferDescription = offer.OfferDescription,
                OfferImage1 = offer.OfferImage1,
                OfferImage2 = offer.OfferImage2,
                OfferTitle = offer.OfferTitle,
                OfferSubTitle = offer.OfferSubTitle,
                CreatedAt = offer.CreatedAt,
                Status = offer.Status
            };

            return result;
        }
    }
}