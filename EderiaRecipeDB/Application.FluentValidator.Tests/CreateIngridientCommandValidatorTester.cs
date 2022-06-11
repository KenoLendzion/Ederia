using NUnit.Framework;
using FluentValidation;
using FluentValidation.TestHelper;
using Application.Ingridients.Commands.CreateIngridient;
using System;

namespace Application.FluentValidator.Tests
{
    public class CreateIngridientCommandValidatorTester
    {
        private CreateIngridientCommandValidator validator;

       [SetUp]
        public void SetUp()
        {
            validator = new CreateIngridientCommandValidator();
        }

        [Test]
        public void Should_Have_Error_When_Name_Is_More_Than_300_Characters()
        {
            var model = new CreateIngridientCommand
            {
                Id = Guid.NewGuid(),
                Name = "asdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvaasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvsdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcvasdfghyxcv"
            };

            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(model => model.Name);
        }
    }
}
