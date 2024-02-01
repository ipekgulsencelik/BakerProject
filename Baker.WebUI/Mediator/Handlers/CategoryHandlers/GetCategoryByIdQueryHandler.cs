using AutoMapper;
using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Queries.CategoryQueries;
using Baker.WebUI.Mediator.Results.CategoryResults;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdQueryResult>
    {
        private readonly IMongoCollection<Category> _collection;
        private readonly IMapper _mapper;

        public GetCategoryByIdQueryHandler(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _collection.Find(x => x.ID == request.Id).FirstOrDefaultAsync();
            var result = _mapper.Map<GetCategoryByIdQueryResult>(category);

            return result;
        }
    }
}