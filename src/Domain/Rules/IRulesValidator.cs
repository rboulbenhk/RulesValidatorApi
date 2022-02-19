namespace RulesValidatorApi.Domain.Rules;
public interface IRulesValidator
{
    bool IsValid();
    string GetErrorMessage();
}