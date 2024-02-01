using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Commands.ProductCommands;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.ProductHandlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IMongoCollection<Product> _collection;

        public CreateProductCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var values = new Product
            {
                ProductName = request.ProductName,
                ProductImage = request.ProductImage,
                ProductDescription = request.ProductDescription,
                ProductPrice = request.ProductPrice,
                ProductStock = request.ProductStock,
                CategoryName = request.CategoryName,
                CreatedAt = request.CreatedAt,
                IsHome = request.IsHome,
                Status = request.Status
            };

            await _collection.InsertOneAsync(values, cancellationToken);
        }
    }
}