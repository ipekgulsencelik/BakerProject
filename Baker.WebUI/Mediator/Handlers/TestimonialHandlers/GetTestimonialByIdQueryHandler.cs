using AutoMapper;
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
        private readonly IMongoCollection<Testimonial> _testimonialCollection;
        private readonly IMapper _mapper;

        public GetTestimonialByIdQueryHandler(IDatabaseSettings databaseSettings, IMapper mapper)
        {
            var client = new MongoClient();
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _testimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);
            _mapper = mapper;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery request, CancellationToken cancellationToken)
        {
            var testimonial = await _testimonialCollection.Find(x=>x.ID==request.Id).FirstOrDefaultAsync();
            var result = _mapper.Map<GetTestimonialByIdQueryResult>(testimonial);
            return result;
        }
    }
}