using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Queries.OfferQueries;
using Baker.WebUI.CQRS.Results.OfferResults;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.OfferHandlers
{
    public class GetOfferByIdQueryHandler
    {
        private readonly IMongoCollection<Offer> _collection;

        public GetOfferByIdQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Offer>(databaseSettings.OfferCollectionName);
        }

        public GetOfferByIdQueryResult Handle(GetOfferByIdQuery query)
        {
            var values = Builders<Offer>.Filter.Eq(x => x.ID, query.Id);

            var offer = _collection.Find(values).FirstOrDefault();

            var result = new GetOfferByIdQueryResult
            {
                OfferID = offer.ID,
                OfferTitle = offer.OfferTitle,
                OfferSubTitle = offer.OfferSubTitle,
                OfferDescription = offer.OfferDescription,
                OfferImage1 = offer.OfferImage1,
                OfferImage2 = offer.OfferImage2,
                CreatedAt = offer.CreatedAt,
                Status = offer.Status
            };

            return result;
        }
    }
}