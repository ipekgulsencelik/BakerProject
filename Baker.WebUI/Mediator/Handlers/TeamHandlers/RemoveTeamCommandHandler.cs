using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Commands.TeamCommands;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.TeamHandlers
{
    public class RemoveTeamCommandHandler : IRequestHandler<RemoveTeamCommand>
    {
        private readonly IMongoCollection<Team> _collection;

        public RemoveTeamCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }

        public async Task Handle(RemoveTeamCommand request, CancellationToken cancellationToken)
        {
            var value = Builders<Team>.Filter.Eq(x => x.ID, request.Id);

            await _collection.DeleteOneAsync(value, cancellationToken);
        }
    }
}