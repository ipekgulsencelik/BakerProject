using Baker.WebUI.Mediator.Results.TestimonialResults;
using MediatR;

namespace Baker.WebUI.Mediator.Queries.TestimonialQueries
{
    public class GetTestimonialQuery : IRequest<List<GetTestimonialQueryResult>>
    {
    }
}