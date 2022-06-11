using NUnit.Framework;
using FluentValidation;
using FluentValidation.TestHelper;
using Application.Recipes.Commands.CreateRecipe;
using System;

namespace Application.FluentValidation.Tests
{
    [TestFixture]
    public class CreateRecipeCommandValidatorTester
    {
        private CreateRecipeCommandValidator validator;

        [SetUp]
        public void SetUp()
        {
            validator = new CreateRecipeCommandValidator();
        }

        [Test]
        public void Should_have_error_when_Name_is_longer_than_300_Characters()
        {
            var model = new CreateRecipeCommand
            {
                Name = "abcdefghijcdefghijababcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghijabcdefghij"
            };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Name);
        }
    }
}
