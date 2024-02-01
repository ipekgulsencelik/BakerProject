using AutoMapper;
using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Queries.AboutQueries;
using Baker.WebUI.CQRS.Results.AboutResults;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IMongoCollection<About> _collection;
        private readonly IMapper _mapper;

        public GetAboutByIdQueryHandler(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public GetAboutByIdQueryResult Handle(GetAboutByIdQuery query)
        {
            var about = _collection.Find(x => x.ID == query.Id).FirstOrDefault();
            var result = _mapper.Map<GetAboutByIdQueryResult>(about);

            return result;
        }
    }
}