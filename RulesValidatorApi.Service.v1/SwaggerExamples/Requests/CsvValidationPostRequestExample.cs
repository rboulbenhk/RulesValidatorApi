using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;
using RulesValidatorApi.Service.v1.Contracts.V1.Requests;
using RulesValidatorApi.Service.v1.Helper;
using RulesValidatorApi.Service.v1.Rules;
using Swashbuckle.AspNetCore.Filters;

namespace RulesValidatorApi.Service.v1.SwaggerExamples.Requests
{
    public class CsvValidationPostRequestExample : IExamplesProvider<CsvValidationPostRequest>
    {
        private readonly IOptionsMonitor<IEnumerable<RuleSetOptions>> _ruleSetOptions;

        public CsvValidationPostRequestExample(IOptionsMonitor<IEnumerable<RuleSetOptions>> ruleSetOptions)
        {
            _ruleSetOptions = ruleSetOptions;
        }

        public CsvValidationPostRequest GetExamples()
        {
            //TODO retrieve the RuleSetOptions and display them in the swagger
            var informations = _ruleSetOptions.CurrentValue.Select(r => r.DisplayInformation());
            var ruleSetRequest = new PostRuleSetRequest();
            ruleSetRequest.ColumnId = 1;
            ruleSetRequest.RuleName = "The name of the rule to apply on this column";
            ruleSetRequest.Arguments = new List<string>{"Optional argument used to validate the rule"};
            return new CsvValidationPostRequest
            {
                FilePath = "The path of the CSV file you want to validate",
                RuleSet = new List<PostRuleSetRequest>{ruleSetRequest}
            };
        }
    }
}