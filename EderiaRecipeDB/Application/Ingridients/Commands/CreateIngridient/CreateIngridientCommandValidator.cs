using FluentValidation;

namespace Application.Ingridients.Commands.CreateIngridient
{
    public class CreateIngridientCommandValidator : AbstractValidator<CreateIngridientCommand>
    {
        public CreateIngridientCommandValidator()
        {
            // TODO CreateIngridientCommandValidator
            RuleFor(v => v.Name).MaximumLength(300);
        }
    }
}
