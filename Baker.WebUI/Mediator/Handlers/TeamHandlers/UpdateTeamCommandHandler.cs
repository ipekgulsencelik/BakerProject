using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Commands.TeamCommands;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.TeamHandlers
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand>
    {
        private readonly IMongoCollection<Team> _collection;

        public UpdateTeamCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }

        public async Task Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var value = Builders<Team>.Filter.Eq(x => x.ID, request.ID);

            var team = Builders<Team>.Update
                .Set(x => x.TeamTitle, request.TeamTitle)
                .Set(x => x.TeamFullName, request.TeamFullName)
                .Set(x => x.TeamImageURL, request.TeamImageURL)
                .Set(x => x.CreatedAt, request.CreatedAt)
                .Set(x => x.IsHome, request.IsHome)
                .Set(x => x.Status, request.Status);

            await _collection.UpdateOneAsync(value, team, null, cancellationToken);
        }
    }
}