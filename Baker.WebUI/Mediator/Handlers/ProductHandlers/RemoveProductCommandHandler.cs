using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Commands.ProductCommands;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.ProductHandlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly IMongoCollection<Product> _collection;

        public RemoveProductCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var value = Builders<Product>.Filter.Eq(x => x.ID, request.Id);

            await _collection.DeleteOneAsync(value, cancellationToken);
        }
    }
}