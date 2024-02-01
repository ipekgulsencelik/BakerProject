using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Commands.CategoryCommands;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.CategoryHandlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IMongoCollection<Category> _collection;

        public UpdateCategoryCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var value = Builders<Category>.Filter.Eq(x => x.ID, request.ID);

            var team = Builders<Category>.Update
                .Set(x => x.CategoryName, request.CategoryName)
                .Set(x => x.CategoryDescription, request.CategoryDescription)
                .Set(x => x.CategoryImage, request.CategoryImage)
                .Set(x => x.CreatedAt, request.CreatedAt)
                .Set(x => x.IsHome, request.IsHome)
                .Set(x => x.Status, request.Status);

            await _collection.UpdateOneAsync(value, team, null, cancellationToken);
        }
    }
}