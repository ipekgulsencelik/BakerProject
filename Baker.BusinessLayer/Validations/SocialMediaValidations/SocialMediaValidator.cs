using Baker.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baker.BusinessLayer.Validations.SocialMediaValidations
{
	public class SocialMediaValidator : AbstractValidator<SocialMedia>
	{
		public SocialMediaValidator()
		{
			RuleFor(x => x.Icon).NotEmpty().WithMessage("İkon Alanı Boş Geçilemez.");
			RuleFor(x => x.URL).NotEmpty().WithMessage("Hesap URL Bilgisi Alanı Boş Geçilemez.");
		}
	}
}