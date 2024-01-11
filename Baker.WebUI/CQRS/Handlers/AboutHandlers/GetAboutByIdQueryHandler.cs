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

        public GetAboutByIdQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }

        public GetAboutByIdQueryResult Handle(GetAboutByIdQuery query)
        {
            var values = Builders<About>.Filter.Eq(x => x.ID, query.Id);

            var about = _collection.Find(values).FirstOrDefault();

            var result = new GetAboutByIdQueryResult
            {
                AboutID = about.ID,
                AboutTitle = about.AboutTitle,
                AboutSubTitle = about.AboutSubTitle,
                AboutDescription1 = about.AboutDescription1,
                AboutDescription2 = about.AboutDescription2,
                AboutImage1 = about.AboutImage1,
                AboutImage2 = about.AboutImage2,
                CreatedAt = about.CreatedAt,
                Status = about.Status
            };

            return result;
        }
    }
}