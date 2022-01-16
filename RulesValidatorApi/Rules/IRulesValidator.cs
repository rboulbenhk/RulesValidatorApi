namespace RulesValidatorApi.Rules
{
    public interface IRulesValidator
    {
        bool IsValid();
        string GetErrorMessage();
    }
} 