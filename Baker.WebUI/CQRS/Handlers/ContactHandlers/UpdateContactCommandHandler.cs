using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Commands.ContactCommands;
using MongoDB.Driver;

namespace Baker.WebUI.CQRS.Handlers.ContactHandlers
{
	public class UpdateContactCommandHandler
	{
		private readonly IMongoCollection<Contact> _collection;

		public UpdateContactCommandHandler(IDatabaseSettings databaseSettings)
		{
			var client = new MongoClient(databaseSettings.ConnectionString);
			var database = client.GetDatabase(databaseSettings.DatabaseName);
			_collection = database.GetCollection<Contact>(databaseSettings.ContactCollectionName);
		}

		public void Handle(UpdateContactCommand command)
		{
			var values = Builders<Contact>.Filter.Eq(x => x.ID, command.ContactID);

			var contact = Builders<Contact>.Update
				.Set(x => x.Title, command.Title)
				.Set(x => x.Address, command.Address)
				.Set(x => x.EmailAddress, command.EmailAddress)
				.Set(x => x.PhoneNumber, command.PhoneNumber)
				.Set(x => x.CreatedAt, command.CreatedAt)
				.Set(x => x.Status, command.Status);

			_collection.UpdateOne(values, contact);
		}
	}
}