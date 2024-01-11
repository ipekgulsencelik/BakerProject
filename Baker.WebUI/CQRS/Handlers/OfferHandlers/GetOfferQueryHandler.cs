using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
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

        public List<GetOfferQueryResult> Handle()
        {
            var values = _collection.Find(FilterDefinition<Offer>.Empty).ToList();

            var result = values.Select(offer => new GetOfferQueryResult
            {
                OfferID = offer.ID,
                OfferDescription = offer.OfferDescription,
                OfferImage1 = offer.OfferImage1,
                OfferImage2 = offer.OfferImage2,
                OfferTitle = offer.OfferTitle,
                OfferSubTitle = offer.OfferSubTitle,
                CreatedAt = offer.CreatedAt,
                Status = offer.Status
            }).ToList();

            return result;
        }
    }
}