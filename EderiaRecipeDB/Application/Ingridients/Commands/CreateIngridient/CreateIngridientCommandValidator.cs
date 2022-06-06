using FluentValidation;

namespace Application.Ingridients.Commands.CreateIngridient
{
    public class CreateIngridientCommandValidator : AbstractValidator<CreateIngridientCommand>
    {
        public CreateIngridientCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
            RuleFor(v => v.Name).MaximumLength(300);
        }
    }
}
