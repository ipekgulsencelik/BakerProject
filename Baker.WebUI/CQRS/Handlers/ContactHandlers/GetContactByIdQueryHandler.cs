using AutoMapper;
using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Queries.AboutQueries;
using Baker.WebUI.CQRS.Queries.ContactQueries;
using Baker.WebUI.CQRS.Results.AboutResults;
using Baker.WebUI.CQRS.Results.ContactResults;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.ContactHandlers
{
	public class GetContactByIdQueryHandler
	{
		private readonly IMongoCollection<Contact> _collection;
		private readonly IMapper _mapper;

		public GetContactByIdQueryHandler(IDatabaseSettings databaseSettings, IMapper mapper)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_collection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
			_mapper = mapper;
		}

		public GetContactByIdQueryResult Handle(GetContactByIdQuery query)
		{
			var contact = _collection.Find(x => x.ID == query.Id).FirstOrDefault();
			var result = _mapper.Map<GetContactByIdQueryResult>(contact);

			return result;
		}
	}
}