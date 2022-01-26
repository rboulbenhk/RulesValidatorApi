using Swashbuckle.AspNetCore.Filters;

namespace RulesValidatorApi.Service.v1.SwaggerExamples.Requests
{
    public class CsvValidationPostRequestExample : IExamplesProvider<CsvValidationPostRequest>
    {
        public CsvValidationPostRequest GetExamples()
        {            
            var ruleSetRequest = new PostRuleSetRequest();
            ruleSetRequest.ColumnId = 1;
            ruleSetRequest.RuleName = "The name of the rule to apply on this column";
            ruleSetRequest.ArgumentValues = new string[]{"Optional argument used to validate the rule"};
            
            return new CsvValidationPostRequest
            {
                FilePath = "The path of the CSV file you want to validate",
                RuleSet = new PostRuleSetRequest[]{ruleSetRequest}
            };
        }
    }
}