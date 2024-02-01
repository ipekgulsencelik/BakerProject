using AutoMapper;
using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Queries.ProductQueries;
using Baker.WebUI.Mediator.Results.ProductResults;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.ProductHandlers
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdQueryResult>
    {
        private readonly IMongoCollection<Product> _collection;
        private readonly IMapper _mapper;

        public GetProductByIdQueryHandler(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient();
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _collection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            _mapper = mapper;
        }

        public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _collection.Find(x => x.ID == request.Id).FirstOrDefaultAsync();
            var result = _mapper.Map<GetProductByIdQueryResult>(product);
            return result;
        }
    }
}