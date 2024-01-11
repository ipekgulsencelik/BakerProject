using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Results.AboutResults;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.AboutHandlers
{
    public class GetAboutQueryHandler
    {
        private readonly IMongoCollection<About> _collection;

        public GetAboutQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }

        public List<GetAboutQueryResult> Handle()
        {
            var values = _collection.Find(FilterDefinition<About>.Empty).ToList();

            var result = values.Select(about => new GetAboutQueryResult
            {
                AboutID = about.ID,
                AboutDescription1 = about.AboutDescription1,
                AboutDescription2 = about.AboutDescription2,
                AboutImage1 = about.AboutImage1,
                AboutImage2 = about.AboutImage2,
                AboutTitle = about.AboutTitle,
                AboutSubTitle = about.AboutSubTitle,
                CreatedAt = about.CreatedAt,
                Status = about.Status
            }).ToList();

            return result;
        }
    }
}