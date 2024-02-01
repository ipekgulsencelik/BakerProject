using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Commands.CategoryCommands;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.CategoryHandlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
    {
        private readonly IMongoCollection<Category> _collection;

        public CreateCategoryCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var values = new Category
            {
                CategoryName = request.CategoryName,
                CategoryDescription = request.CategoryDescription,
                CategoryImage = request.CategoryImage,
                CreatedAt = request.CreatedAt,
                IsHome = request.IsHome,
                Status = request.Status
            };

            await _collection.InsertOneAsync(values, cancellationToken);
        }
    }
}