using CentricExpress.Business.DTOs;

using FluentValidation;

namespace CentricExpress.Business.Validators
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(o => o.CustomerId).NotEmpty();
            RuleFor(o => o.OrderLines).NotEmpty();
        }
    }
}