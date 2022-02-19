namespace RulesValidatorApi.Domain.Rules.CsvFileCellRules;
public abstract class RulesValidatorBase : IRulesValidator
{
    public abstract bool IsValid();
    public abstract string GetErrorMessage();
    public abstract string Name { get; }
}