using FluentValidation;

namespace Application.RecipeIngridients.Commands.CreateRecipeIngridient
{
    public class CreateRecipeIngridientCommandValidator : AbstractValidator<CreateRecipeIngridientCommand>
    {
        public CreateRecipeIngridientCommandValidator()
        {
            RuleFor(v => v.RecipeId).GreaterThan(0);
            RuleFor(v => v.IngridientId).GreaterThan(0);
            RuleFor(v => v.Amount).GreaterThanOrEqualTo(0).NotEmpty();
        }
    }
}
