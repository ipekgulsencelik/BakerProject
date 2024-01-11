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

        public GetTeamByIdQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }

        public async Task<GetTeamByIdQueryResult> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var values = Builders<Team>.Filter.Eq(x => x.ID, request.Id);

            var team = await _collection.Find(values).FirstOrDefaultAsync(cancellationToken); ;

            var result = new GetTeamByIdQueryResult
            {
                ID = team.ID,
                TeamTitle = team.TeamTitle,
                TeamFullName = team.TeamFullName,
                TeamImageURL = team.TeamImageURL,
                CreatedAt = team.CreatedAt,
                IsHome = team.IsHome,
                Status = team.Status
            };

            return result;
        }
    }
}