using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Queries.CategoryQueries;
using Baker.WebUI.Mediator.Results.CategoryResults;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.CategoryHandlers
{
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<GetCategoryQueryResult>>
    {
        private readonly IMongoCollection<Category> _collection;

        public GetCategoryQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
        }

        public async Task<List<GetCategoryQueryResult>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var value = Builders<Category>.Filter.Empty;
            var category = Builders<Category>.Projection
                .Include(x => x.ID)
                .Include(x => x.CategoryName)
                .Include(x => x.CategoryDescription)
                .Include(x => x.CategoryImage)
                .Include(x => x.CreatedAt)
                .Include(x => x.IsHome)
                .Include(x => x.Status);

            var result = await _collection.Find(value).Project<GetCategoryQueryResult>(category).ToListAsync(cancellationToken);

            return result;
        }
    }
}