using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Queries.TestimonialQueries;
using Baker.WebUI.Mediator.Results.TestimonialResults;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly IMongoCollection<Testimonial> _collection;

        public GetTestimonialByIdQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }
        
        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var values = Builders<Testimonial>.Filter.Eq(x => x.ID, request.Id);

            var testimonial = await _collection.Find(values).FirstOrDefaultAsync(cancellationToken);

            var result = new GetTestimonialByIdQueryResult
            {
                ID = testimonial.ID,
                TestimonialTitle = testimonial.TestimonialTitle,
                TestimonialComment = testimonial.TestimonialComment,
                TestimonialFullName = testimonial.TestimonialFullName,
                TestimonialImageURL = testimonial.TestimonialImageURL,
                CreatedAt = testimonial.CreatedAt,
                IsHome = testimonial.IsHome,
                Status = testimonial.Status
            };

            return result;
        }
    }
}