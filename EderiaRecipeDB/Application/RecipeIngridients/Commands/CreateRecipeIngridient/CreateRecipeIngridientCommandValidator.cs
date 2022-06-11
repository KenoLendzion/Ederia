using FluentValidation;

namespace Application.RecipeIngridients.Commands.CreateRecipeIngridient
{
    public class CreateRecipeIngridientCommandValidator : AbstractValidator<CreateRecipeIngridientCommand>
    {
        public CreateRecipeIngridientCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
            RuleFor(v => v.RecipeId).NotEmpty();
            RuleFor(v => v.IngridientId).NotEmpty();
        }
    }
}
