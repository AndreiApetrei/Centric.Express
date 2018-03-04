using CentricExpress.Business.DTOs;

using FluentValidation;

namespace CentricExpress.Business.Validators
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            //TODO: see about customerId - foreign key?
            //RuleFor(o => o.CustomerId).NotEmpty();

            RuleFor(o => o.OrderLines).NotEmpty();
        }
    }
}