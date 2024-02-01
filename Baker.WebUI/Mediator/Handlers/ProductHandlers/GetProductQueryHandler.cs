using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Queries.ProductQueries;
using Baker.WebUI.Mediator.Results.ProductResults;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.ProductHandlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, List<GetProductQueryResult>>
    {
        private readonly IMongoCollection<Product> _collection;

        public GetProductQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
        }

        public async Task<List<GetProductQueryResult>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var value = Builders<Product>.Filter.Empty;
            var team = Builders<Product>.Projection
                .Include(x => x.ID)
                .Include(x => x.ProductName)
                .Include(x => x.ProductDescription)
                .Include(x => x.ProductImage)
                .Include(x => x.ProductPrice)
                .Include(x => x.ProductStock)
                .Include(x => x.CategoryName)
                .Include(x => x.CreatedAt)
                .Include(x => x.IsHome)
                .Include(x => x.Status);

            var result = await _collection.Find(value).Project<GetProductQueryResult>(team).ToListAsync(cancellationToken);

            return result;
        }
    }
}