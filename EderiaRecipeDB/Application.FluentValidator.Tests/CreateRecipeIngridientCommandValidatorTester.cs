using FluentValidation.TestHelper;
using Application.RecipeIngridients.Commands.CreateRecipeIngridient;
using NUnit.Framework;

namespace Application.FluentValidator.Tests
{
    [TestFixture]
    public class CreateRecipeIngridientCommandValidatorTester
    {
        private CreateRecipeIngridientCommandValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new CreateRecipeIngridientCommandValidator();
        }

        [Test]
        public void ShouldThrowErrorWhenRecipeIdIsZero()
        {
            var model = new CreateRecipeIngridientCommand
            {
                IngridientId = 1,
                Amount = 12
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.RecipeId);
        }

        [Test]
        public void ShouldThrowErrorWhenIngridientIdIsZero()
        {
            var model = new CreateRecipeIngridientCommand
            {
                RecipeId = 1,
                Amount = 13
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.IngridientId);
        }

        [Test]
        public void ShouldThrowErrorWhenAmountIsLessThanZero()
        {
            var model = new CreateRecipeIngridientCommand
            {
                Amount = -1
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Amount);
        }
    }
}
