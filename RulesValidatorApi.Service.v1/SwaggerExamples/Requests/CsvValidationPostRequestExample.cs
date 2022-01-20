using System.Collections.Generic;
using RulesValidatorApi.Service.v1.Contracts.V1.Requests;
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
            ruleSetRequest.Argument = new List<string>{"Optional argument to provide to apply the rule"};
            return new CsvValidationPostRequest
            {
                FilePath = "The path of the CSV file you want to validate",
                RuleSetConfiguration = new List<PostRuleSetRequest>{ruleSetRequest}
            };
        }
    }
}