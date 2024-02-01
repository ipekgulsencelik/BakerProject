using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Commands.TestimonialCommands;
using Baker.WebUI.Mediator.Results.TestimonialResults;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.TestimonialHandlers
{
    public class ChangeTestimonialStatusCommandHandler : IRequestHandler<ChangeTestimonialStatusCommand>
    {
        private readonly IMongoCollection<Testimonial> _collection;

        public ChangeTestimonialStatusCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }

        public async Task Handle(ChangeTestimonialStatusCommand request, CancellationToken cancellationToken)
        {
            var filter = Builders<Testimonial>.Filter.Eq(x => x.ID, request.Id);

            var testimonial = await _collection.Find(filter).FirstOrDefaultAsync();

            if (testimonial.Status == true)
            {
                request.Status = false;
            }
            else
            {
                request.Status = true;
            }

            var update = Builders<Testimonial>.Update.Set(x => x.Status, request.Status);

            await _collection.UpdateOneAsync(filter, update, null, cancellationToken);
        }
    }
}