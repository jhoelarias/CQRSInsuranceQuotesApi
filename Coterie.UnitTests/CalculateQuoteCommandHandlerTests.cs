using Coterie.Domain.Commands.QuoteCommands;
using Coterie.Domain.Enums;
using Coterie.Domain.Extensions;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Coterie.UnitTests
{
    internal class CalculateQuoteCommandHandlerTests : CalculateQuoteCommandHandlerTestBase
    {
        [TestCaseSource(nameof(HappyCases))]
        public async Task CalculateQuoteCommandHandler_When_Three_States_Then_Returns_Three_Premiums(CalculateQuoteCommand request)
        {
            var actual = await _calculateQuoteCommandHandler.Handle(request, new CancellationToken());
            Assert.That(actual.Result.Premiums.Count, Is.EqualTo(request.States.Count));
        }

        [Test]
        public async Task CalculateQuoteCommandHandler_When_Values_Are_Valid_Returns_Correct_Premiums()
        {
            // Arrange
            var calculateQuoteCommand = new CalculateQuoteCommand
            {
                Revenue = 6000000,
                Business = BusinessEnum.Plumber.GetDescription(),
                States = new List<string> { StatesEnum.TX.GetDescription() }
            };

            // Assert
            var actual = await _calculateQuoteCommandHandler.Handle(calculateQuoteCommand, new CancellationToken());
            foreach (var resultPremium in actual.Result.Premiums)
            {
                Assert.That(resultPremium.Premium, Is.EqualTo(StateResults[resultPremium.State]));
            }
        }
    }
}