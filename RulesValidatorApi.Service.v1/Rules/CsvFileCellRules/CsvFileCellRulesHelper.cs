namespace RulesValidatorApi.Service.Rules.CsvFileCellRules
{   
    public static class CsvFileCellRulesHelper
    {
        public static IDictionary<string,IRulesValidator> AllRules = new Dictionary<string,IRulesValidator>()
        {
            {nameof(IsBoolean),new IsBoolean()},
            {nameof(IsCaseSensitiveStringFromSpecifiedList),new IsCaseSensitiveStringFromSpecifiedList()},
            {nameof(IsDelimeterSepcified),new IsDelimeterSepcified()},
            {nameof(IsEmpty),new IsBoolean()},

        };
    }
}