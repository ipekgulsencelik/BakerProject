using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Commands.TestimonialCommands;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly IMongoCollection<Testimonial> _collection;

        public CreateTestimonialCommandHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }

        public async Task Handle(CreateTestimonialCommand request, CancellationToken cancellationToken)
        {
            var values = new Testimonial
            {
                TestimonialFullName = request.TestimonialFullName,
                TestimonialImageURL = request.TestimonialImageURL,
                TestimonialTitle = request.TestimonialTitle,
                TestimonialComment = request.TestimonialComment,
                CreatedAt = request.CreatedAt,
                IsHome = request.IsHome,
                Status = request.Status
            };

            await _collection.InsertOneAsync(values, cancellationToken);
        }
    }
}