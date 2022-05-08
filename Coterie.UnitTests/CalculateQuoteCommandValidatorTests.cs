using Coterie.Domain.Commands.QuoteCommands;
using FluentValidation.TestHelper;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Coterie.UnitTests
{
    internal class CalculateQuoteCommandValidatorTests : CalculateQuoteCommandValidatorTestBase
    {
        [TestCaseSource(nameof(HappyCases))]
        public async Task CalculateQuoteCommandValidator_When_Everything_Is_Okay_Then_Validation_Should_Pass(CalculateQuoteCommand request)
        {
            var result = await _calculateQuoteCommandValidator.TestValidateAsync(request);
            Assert.IsTrue(result.IsValid);
        }

        [Test]
        public async Task CalculateQuoteCommandValidator_When_Revenue_Is_Zero_Then_ShouldHaveValidationError()
        {
            // Arrange
            // Assert
            var result = await _calculateQuoteCommandValidator.TestValidateAsync(new CalculateQuoteCommand
            {
                Revenue = 0,
                Business = "Plumber",
                States = new List<string> { "TX" }
            });

            result.ShouldHaveValidationErrorFor(r => r.Revenue);
        }

        [Test]
        public async Task CalculateQuoteCommandValidator_When_Business_Is_Null_Then_ShouldHaveValidationError()
        {
            // Arrange
            // Assert
            var result = await _calculateQuoteCommandValidator.TestValidateAsync(new CalculateQuoteCommand
            {
                Revenue = 50000,
                States = new List<string> { "TX" }
            });

            result.ShouldHaveValidationErrorFor(r => r.Business);
        }

        [Test]
        public async Task CalculateQuoteCommandValidator_When_States_Is_Null_Then_ShouldHaveValidationError()
        {
            // Arrange
            // Assert
            var result = await _calculateQuoteCommandValidator.TestValidateAsync(new CalculateQuoteCommand
            {
                Revenue = 50000,
                Business = "Plumber"
            });

            result.ShouldHaveValidationErrorFor(r => r.States);
        }

        [TestCaseSource(nameof(StatesWrongCases))]
        public async Task CalculateQuoteCommandValidator_When_States_is_Wrong_Then_ShouldHaveValidationError(CalculateQuoteCommand request)
        {
            // Arrange
            // Assert
            var result = await _calculateQuoteCommandValidator.TestValidateAsync(request);

            result.ShouldHaveValidationErrorFor(r => r.States);
        }
    }
}