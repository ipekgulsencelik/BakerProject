using Baker.EntityLayer.Concrete;
using FluentValidation;

namespace Baker.BusinessLayer.Validations.CarouselValidations
{
	public class CarouselValidator : AbstractValidator<Carousel>
	{
		public CarouselValidator()
		{
			RuleFor(x => x.MainTitle).NotEmpty().WithMessage("Ana-Başlık Bilgisi Alanı Boş Geçilemez.");
			RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık Bilgisi Alanı Boş Geçilemez.");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Bilgisi Boş Geçilemez.");
		}
	}
}