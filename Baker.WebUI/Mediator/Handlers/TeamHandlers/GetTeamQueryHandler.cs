using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Queries.TeamQueries;
using Baker.WebUI.Mediator.Results.TeamResults;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.TeamHandlers
{
    public class GetTeamQueryHandler : IRequestHandler<GetTeamQuery, List<GetTeamQueryResult>>
    {
        private readonly IMongoCollection<Team> _collection;

        public GetTeamQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }

        public async Task<List<GetTeamQueryResult>> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var value = Builders<Team>.Filter.Empty;
            var team = Builders<Team>.Projection
                .Include(x => x.ID)
                .Include(x => x.TeamFullName)
                .Include(x => x.TeamTitle)
                .Include(x => x.TeamImageURL)
                .Include(x => x.CreatedAt)
                .Include(x => x.IsHome)
                .Include(x => x.Status);

            var result = await _collection.Find(value).Project<GetTeamQueryResult>(team).ToListAsync(cancellationToken);

            return result;
        }
    }
}