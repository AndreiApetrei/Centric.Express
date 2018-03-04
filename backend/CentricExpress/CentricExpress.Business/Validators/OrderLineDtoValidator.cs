using CentricExpress.Business.DTOs;

using FluentValidation;

namespace CentricExpress.Business.Validators
{
    public class OrderLineDtoValidator : AbstractValidator<OrderLineDto>
    {
        public OrderLineDtoValidator()
        {
            RuleFor(o => o.ItemId).NotEmpty();
            RuleFor(o => o.Quantity).GreaterThan(0);
        }
    }
}