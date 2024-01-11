using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Commands.TeamCommands;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.TeamHandlers
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand>
    {
        private readonly IMongoCollection<Team> _collection;

        public CreateTeamCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Team>(databaseSettings.TeamCollectionName);
        }

        public async Task Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var values = new Team
            {
                TeamFullName = request.TeamFullName,
                TeamImageURL = request.TeamImageURL,
                TeamTitle = request.TeamTitle,
                CreatedAt = request.CreatedAt,
                IsHome = request.IsHome,
                Status = request.Status
            };

            await _collection.InsertOneAsync(values, cancellationToken);
        }
    }
}