using System;
using Coterie.Domain.Commands.QuoteCommands;
using Coterie.Services.CommandHandlers.QuoteCommandHandlers;
using NUnit.Framework;
using System.Collections.Generic;
using Coterie.Data;

namespace Coterie.UnitTests
{
    internal class CalculateQuoteCommandHandlerTestBase
    {
        protected QuoteCommandHandlers.CalculateQuoteCommandHandler _calculateQuoteCommandHandler;

        [OneTimeSetUp]
        public void BaseOneTimeSetup()
        {
            CoterieContextFactory contextFactory = new();
            ICoterieContext context = contextFactory.CreateDbContext(new[] { "DataSource=..\\..\\..\\..\\Coterie.Data\\DataBaseMigrations\\coterie.db" });
            _calculateQuoteCommandHandler = new QuoteCommandHandlers.CalculateQuoteCommandHandler(context);
        }

        [TearDown]
        public void Cleanup()
        {
            // Sample reset after each test is ran
            //MockTestService.Reset();
        }

        protected static List<CalculateQuoteCommand> HappyCases = new()
        {
            new CalculateQuoteCommand
            {
                Revenue = 600000,
                Business = "Plumber",
                States = new List<string> { "TEXAS", "FLORIDA", "OHIO" }
            },
            new CalculateQuoteCommand
            {
                Revenue = 7000,
                Business = "Architect",
                States = new List<string> { "TX", "FL", "OH" }
            },
            new CalculateQuoteCommand
            {
                Revenue = 600000,
                Business = "Programmer",
                States = new List<string> { "TX", "FLORIDA", "OHIO" }
            }
        };

        protected static Dictionary<string, double> StateResults = new()
        {
            { "TX", 11316 },
            { "FL", 14400 },
            { "OH", 12000 },
        };
    }
}