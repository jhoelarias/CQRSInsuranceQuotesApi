using System;
using Coterie.Domain.Commands.QuoteCommands;
using NUnit.Framework;
using System.Collections.Generic;
using Coterie.Data;
using Coterie.Services.Validators.Shared;
using Coterie.Services.Validators.CommandValidators.QuoteValidators;

namespace Coterie.UnitTests
{
    internal class CalculateQuoteCommandValidatorTestBase
    {
        protected CalculateQuoteCommandValidator _calculateQuoteCommandValidator;

        [OneTimeSetUp]
        public void BaseOneTimeSetup()
        {
            CoterieContextFactory contextFactory = new();
            ICoterieContext context = contextFactory.CreateDbContext(new[] { "DataSource=..\\..\\..\\..\\Coterie.Data\\DataBaseMigrations\\coterie.db" });
            ICommonValidators commonValidators = new CommonValidators(context);
            _calculateQuoteCommandValidator = new CalculateQuoteCommandValidator(commonValidators);
        }

        [TearDown]
        public void Cleanup()
        {
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

        protected static List<CalculateQuoteCommand> StatesWrongCases = new()
        {
            new CalculateQuoteCommand
            {
                Revenue = 600000,
                Business = "Plumber",
                States = new List<string> { "TEXA", "FLORIDA", "OHIO" }
            },
            new CalculateQuoteCommand
            {
                Revenue = 7000,
                Business = "Architect",
                States = new List<string> { "TX", "FL1", "OH" }
            },
            new CalculateQuoteCommand
            {
                Revenue = 600000,
                Business = "Programmer",
                States = new List<string> { "TX", "FLORIDA", "ARKANSAS" }
            },
            new CalculateQuoteCommand
            {
                Revenue = 600000,
                Business = "Programmer",
                States = new List<string> { "TX", "FLORIDA", "" }
            },
            new CalculateQuoteCommand
            {
                Revenue = 600000,
                Business = "Programmer",
                States = new List<string> { "TZ" }
            }
        };
    }
}