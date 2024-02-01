using AutoMapper;
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
        IMapper _mapper;

        public GetOfferByIdQueryHandler(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Offer>(databaseSettings.OfferCollectionName);
            _mapper = mapper;
        }

        public GetOfferByIdQueryResult Handle(GetOfferByIdQuery query)
        {
            var offer = _collection.Find(x => x.ID == query.Id).FirstOrDefault();
            var result = _mapper.Map<GetOfferByIdQueryResult>(offer);

            return result;
        }
    }
}