using Xunit;
using RulesValidatorApi.Service.ValidatorsApi;

namespace RulesValidatorApi.Service.Tests.v1.Validators
{
    //TODO to rename
    public class CsvConfigurationForValidationDtoValidatorTests
    {
        private readonly CsvValidationPostRequestCommandValidator myValidator;

        public CsvConfigurationForValidationDtoValidatorTests()
        {
            // TODO mock IOptionsMonitor
            // myValidator = new CsvValidationPostRequestCommandValidator();    
        }

        [Fact]
        public void GivenCsvConfigurationForValidationDtoValidator_WhenThePathIsNotCorrect_ThenIHaveAnError()
        {
            // var model = new CsvConfigurationForValidation();
            // var result = myValidator.TestValidate(model);
            // result.ShouldHaveAnyValidationError();
        }
    }
}
