using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Results.ContactResults;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.ContactHandlers
{
	public class GetContactQueryHandler
	{
		private readonly IMongoCollection<Contact> _collection;

		public GetContactQueryHandler(IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_collection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
		}

		public GetContactQueryResult Handle()
		{
			var contact = _collection.Find(FilterDefinition<Contact>.Empty).FirstOrDefault();

            if (contact == null)
            {
                return new GetContactQueryResult();
            }

            var result = new GetContactQueryResult
			{
				ContactID = contact.ID,
				Title = contact.Title,
				Address = contact.Address,
				PhoneNumber = contact.PhoneNumber,
				EmailAddress = contact.EmailAddress,
				CreatedAt = contact.CreatedAt,
				Status = contact.Status
			};

			return result;
		}
	}
}