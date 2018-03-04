using CentricExpress.Business.DTOs;

using FluentValidation;

namespace CentricExpress.Business.Validators
{
    public class ItemDtoValidator : AbstractValidator<ItemDto>
    {
        public ItemDtoValidator()
        {
            RuleFor(i => i.Description).Length(10, 3000)
                                       .WithMessage("{PropertyName}'s length must be between {MinLength} and {MaxLength}");
            RuleFor(i => i.Price).GreaterThan(0);
        }
    }
}