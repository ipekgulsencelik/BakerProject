using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Commands.ProductCommands;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.ProductHandlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IMongoCollection<Product> _collection;

        public UpdateProductCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var value = Builders<Product>.Filter.Eq(x => x.ID, request.ID);

            var team = Builders<Product>.Update
                .Set(x => x.ProductName, request.ProductName)
                .Set(x => x.ProductImage, request.ProductImage)
                .Set(x => x.ProductDescription, request.ProductDescription)
                .Set(x => x.ProductPrice, request.ProductPrice) 
                .Set(x => x.ProductStock, request.ProductStock)
                .Set(x => x.CategoryName, request.CategoryName)
                .Set(x => x.CreatedAt, request.CreatedAt)
                .Set(x => x.IsHome, request.IsHome)
                .Set(x => x.Status, request.Status);

            await _collection.UpdateOneAsync(value, team, null, cancellationToken);
        }
    }
}