using FluentValidation;

namespace Application.UseCases.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        const string RULE_SET = "CreateOrder";

        public CreateOrderCommandValidator()
        {

            RuleFor(o => o.CreateOrderRequest.ProductId)
                .NotNull().WithErrorCode(RULE_SET).WithMessage(e => $"Product Id is Required");

            RuleFor(o => o.CreateOrderRequest.ProductName)
                .NotNull().WithErrorCode(RULE_SET).WithMessage(e => $"Product name is Required")
                .MinimumLength(3)
                .MaximumLength(100);

            RuleFor(o => o.CreateOrderRequest.Quantity)
                .NotNull().WithErrorCode(RULE_SET).WithMessage(e => $"Quantity is Required")
                .GreaterThan(0).WithMessage(e => $"Quantity must be greater than zero");
        }
    }
}
