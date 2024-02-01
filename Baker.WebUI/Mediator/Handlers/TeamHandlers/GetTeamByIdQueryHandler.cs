using AutoMapper;
using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Queries.TeamQueries;
using Baker.WebUI.Mediator.Results.TeamResults;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.TeamHandlers
{
    public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, GetTeamByIdQueryResult>
    {
        private readonly IMongoCollection<Team> _collection;
        private readonly IMapper _mapper;

        public GetTeamByIdQueryHandler(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
            _mapper = mapper;
        }

        public async Task<GetTeamByIdQueryResult> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var team = await _collection.Find(x => x.ID == request.Id).FirstOrDefaultAsync();
            var result = _mapper.Map<GetTeamByIdQueryResult>(team);

            return result;
        }
    }
}