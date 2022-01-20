using Xunit;
using FluentValidation.TestHelper;
using RulesValidatorApi.Service.ValidatorsApi;
using RulesValidatorApi.Service.Domains.Request;

namespace RulesValidatorApi.Service.Tests.v1.Validators
{
    public class CsvConfigurationForValidationDtoValidatorTests
    {
        private readonly CsvConfigurationForValidationValidator myValidator;

        public CsvConfigurationForValidationDtoValidatorTests()
        {
            myValidator = new CsvConfigurationForValidationValidator();    
        }

        [Fact]
        public void GivenCsvConfigurationForValidationDtoValidator_WhenThePathIsNotCorrect_ThenIHaveAnError()
        {
            var model = new CsvConfigurationForValidation();
            var result = myValidator.TestValidate(model);
            result.ShouldHaveAnyValidationError();
        }
    }
}
