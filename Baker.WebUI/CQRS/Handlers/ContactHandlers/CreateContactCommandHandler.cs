using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.ContactCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.ContactHandlers
{
	public class CreateContactCommandHandler
	{
		private readonly IMongoCollection<Contact> _collection;

		public CreateContactCommandHandler(IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_collection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
		}

		public void Handle(CreateContactCommand command)
		{
			var contact = new Contact
			{
				Title = command.Title,
				Address = command.Address,
				PhoneNumber = command.PhoneNumber,
				EmailAddress = command.EmailAddress,
				CreatedAt = command.CreatedAt,
				Status = command.Status
			};

			_collection.InsertOne(contact);
		}
	}
}