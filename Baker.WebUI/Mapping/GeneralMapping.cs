using AutoMapper;
using Baker.DTO.DTOs.CarouselDTOs;
using Baker.EntityLayer.Concrete;
using Baker.WebUI.CQRS.Results.AboutItemResults;
using Baker.WebUI.CQRS.Results.AboutResults;
using Baker.WebUI.CQRS.Results.ContactResults;
using Baker.WebUI.CQRS.Results.OfferResults;
using Baker.WebUI.CQRS.Results.ServiceResults;
using Baker.WebUI.Mediator.Results.CategoryResults;
using Baker.WebUI.Mediator.Results.ProductResults;
using Baker.WebUI.Mediator.Results.TeamResults;
using Baker.WebUI.Mediator.Results.TestimonialResults;
using Baker.WebUI.Models;

namespace Baker.WebUI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<GetAboutByIdQueryResult, About>().ReverseMap();
            CreateMap<GetAboutQueryResult, About>().ReverseMap();

            CreateMap<GetAboutItemByIdQueryResult, AboutItem>().ReverseMap();
            CreateMap<GetAboutItemQueryResult, AboutItem>().ReverseMap();

			CreateMap<ResultCarouselDTO, Carousel>().ReverseMap();
			CreateMap<CreateCarouselDTO, Carousel>().ReverseMap();
			CreateMap<UpdateCarouselDTO, Carousel>().ReverseMap();

			CreateMap<GetCategoryByIdQueryResult, Category>().ReverseMap();
            CreateMap<GetCategoryQueryResult, Category>().ReverseMap();

			CreateMap<GetContactByIdQueryResult, Contact>().ReverseMap();
			CreateMap<GetContactQueryResult, Contact>().ReverseMap();

			CreateMap<GetOfferByIdQueryResult, Offer>().ReverseMap();
            CreateMap<GetOfferQueryResult, Offer>().ReverseMap();

            CreateMap<GetProductByIdQueryResult, Product>().ReverseMap();
            CreateMap<GetProductQueryResult, Product>().ReverseMap();
            CreateMap<GetProductWithCategoryQueryResult, ProductCategory>().ReverseMap();

            CreateMap<GetServiceByIdQueryResult, Service>().ReverseMap();
            CreateMap<GetServiceQueryResult, Service>().ReverseMap();

            CreateMap<GetTestimonialByIdQueryResult, Testimonial>().ReverseMap();
            CreateMap<GetTestimonialQueryResult, Testimonial>().ReverseMap();

            CreateMap<GetTeamByIdQueryResult, Team>().ReverseMap();
            CreateMap<GetTeamQueryResult, Team>().ReverseMap();
        }
    }
}