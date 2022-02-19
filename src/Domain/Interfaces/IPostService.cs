namespace RulesValidatorApi.Domain.Interfaces;
public interface IPostService
{
    Task<IEnumerable<CsvValidationErrorResponse>> PostValidateAsync(CsvConfigurationForValidation csvConfigurationForValidation);
    Task<IEnumerable<CsvRulesResponse>> GetAllCsvRulesAsync();
}