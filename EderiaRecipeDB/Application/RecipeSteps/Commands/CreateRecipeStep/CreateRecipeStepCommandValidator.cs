using FluentValidation;

namespace Application.RecipeSteps.Commands.CreateRecipeStep
{
    public class CreateRecipeStepCommandValidator : AbstractValidator<CreateRecipeStepCommand>
    {
        public CreateRecipeStepCommandValidator()
        {
            // TODO CreateRecipeStepCommandValidator
            RuleFor(v => v.RecipeId).NotEmpty();
            RuleFor(v => v.InstructionText).NotEmpty();
            RuleFor(v => v.SequenceNumber).NotEmpty();
        }
    }
}
