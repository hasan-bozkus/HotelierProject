using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.ValidationRules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim alanı en az 3 karakterli olmalı");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("İsim alanı en az 2 karakterli olmalı");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("İsim alanı en az 3 karakterli olmalı");
            RuleFor(x => x.Name).MaximumLength(20).WithMessage("İsim alanı en fazla 20 karakterli olmalı");
            RuleFor(x => x.City).MaximumLength(30).WithMessage("İsim alanı en fazla 30 karakterli olmalı");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("İsim alanı en fazla 20 karakterli olmalı");
        }
    }
}
