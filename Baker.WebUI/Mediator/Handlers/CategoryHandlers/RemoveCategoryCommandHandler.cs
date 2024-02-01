using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Commands.CategoryCommands;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand>
    {
        private readonly IMongoCollection<Category> _collection;

        public RemoveCategoryCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = Builders<Category>.Filter.Eq(x => x.ID, request.Id);

            await _collection.DeleteOneAsync(value, cancellationToken);
        }
    }
}