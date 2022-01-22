using RulesValidatorApi.Service.v1.Rules;

namespace RulesValidatorApi.Service.v1.Helper
{
    public static class RulesSetOptionsExtensions
    {
        public static string DisplayInformation(this RuleSetOptions ruleSetOption)
        {
            return $"{ruleSetOption.Name}\n{ruleSetOption.Description}\n{ruleSetOption.Example}";
        }
    }
}