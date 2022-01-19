using Xunit;
using FluentValidation.TestHelper;
using RulesValidatorApi.Service.ValidatorsApi;
using RulesValidatorApi.Service.Models.Request;

namespace RulesValidatorApi.Service.Tests.v1.Validators
{
    public class CsvConfigurationForValidationDtoValidatorTests
    {
        private readonly CsvConfigurationForValidationDtoValidator myValidator;

        public CsvConfigurationForValidationDtoValidatorTests()
        {
            myValidator = new CsvConfigurationForValidationDtoValidator();    
        }

        [Fact]
        public void GivenCsvConfigurationForValidationDtoValidator_WhenThePathIsNotCorrect_ThenIHaveAnError()
        {
            var model = new CsvConfigurationForValidationDto();
            var result = myValidator.TestValidate(model);
            result.ShouldHaveAnyValidationError();
        }
    }
}
