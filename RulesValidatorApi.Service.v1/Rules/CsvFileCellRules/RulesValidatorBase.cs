namespace RulesValidatorApi.Service.Rules
{
    public abstract class RulesValidatorBase : IRulesValidator
    {
        public abstract bool IsValid();
        public abstract string GetErrorMessage();
        public abstract string Name { get; }
    }
} 