using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Commands.TestimonialCommands;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly IMongoCollection<Testimonial> _collection;

        public UpdateTestimonialCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }

        public async Task Handle(UpdateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var value = Builders<Testimonial>.Filter.Eq(x => x.ID, request.ID);

            var testimonial = Builders<Testimonial>.Update
                .Set(x => x.TestimonialTitle, request.TestimonialTitle)
                .Set(x => x.TestimonialFullName, request.TestimonialFullName)
                .Set(x => x.TestimonialImageURL, request.TestimonialImageURL)
                .Set(x => x.TestimonialComment, request.TestimonialComment)
                .Set(x => x.CreatedAt, request.CreatedAt)
                .Set(x => x.IsHome, request.IsHome)
                .Set(x => x.Status, request.Status);

            await _collection.UpdateOneAsync(value, testimonial, null, cancellationToken);
        }
    }
}