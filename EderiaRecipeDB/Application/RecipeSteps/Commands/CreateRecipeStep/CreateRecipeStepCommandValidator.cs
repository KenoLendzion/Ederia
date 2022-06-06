using FluentValidation;

namespace Application.RecipeSteps.Commands.CreateRecipeStep
{
    public class CreateRecipeStepCommandValidator : AbstractValidator<CreateRecipeStepCommand>
    {
        public CreateRecipeStepCommandValidator()
        {
            RuleFor(v => v.Id).NotEmpty();
            RuleFor(v => v.RecipeId).NotEmpty();
            RuleFor(v => v.InstructionText).NotEmpty();
            RuleFor(v => v.SequenceNumber).NotEmpty();
        }
    }
}
