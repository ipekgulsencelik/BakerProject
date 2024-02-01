using AutoMapper;
using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Results.AboutResults;
using Baker.WebUI.CQRS.Results.ContactResults;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.AboutHandlers
{
	public class GetAboutQueryHandler
    {
        private readonly IMongoCollection<About> _collection;
        private readonly IMapper _mapper;   

        public GetAboutQueryHandler(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
            _mapper = mapper;
        }

        public GetAboutQueryResult Handle()
        {
            var about = _collection.Find(FilterDefinition<About>.Empty).FirstOrDefault();

            // var result = _mapper.Map<GetAboutQueryResult>(about);

            if (about == null)
            {
                return new GetAboutQueryResult();
            }

            var result = new GetAboutQueryResult
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