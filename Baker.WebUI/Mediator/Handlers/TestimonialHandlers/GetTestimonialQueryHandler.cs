using Baker.DataAccessLayer.Settings;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.Mediator.Queries.TestimonialQueries;
using Baker.WebUI.Mediator.Results.TestimonialResults;
using MediatR;
using MongoDB.Driver;

namespace Baker.WebUI.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IMongoCollection<Testimonial> _collection;

        public GetTestimonialQueryHandler(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _collection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var value = Builders<Testimonial>.Filter.Empty;
            var testimonial = Builders<Testimonial>.Projection
                .Include(x => x.ID)
                .Include(x => x.TestimonialFullName)
                .Include(x => x.TestimonialTitle)
                .Include(x => x.TestimonialImageURL)
                .Include(x => x.TestimonialComment)
                .Include(x => x.CreatedAt)
                .Include(x => x.IsHome)
                .Include(x => x.Status);

            var result = await _collection.Find(value).Project<GetTestimonialQueryResult>(testimonial).ToListAsync(cancellationToken);

            return result;
        }
    }
}