using Baker.WebUI.Mediator.Results.TestimonialResults;
using MediatR;

namespace Baker.WebUI.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery : IRequest<GetTestimonialByIdQueryResult>
    {
        public string Id { get; set; }

        public GetTestimonialByIdQuery(string id)
        {
            Id = id;
        }
    }
}