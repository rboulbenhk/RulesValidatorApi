namespace RulesValidatorApi.Service.Rules
{
    public interface IRulesValidator
    {
        bool IsValid();
        string GetErrorMessage();
    }
} 