global using System.Collections.Generic;
global using MediatR;
global using RulesValidatorApi.Service.v1.Contracts.V1.Requests;
global using RulesValidatorApi.Service.v1.Contracts.V1.Responses;

namespace RulesValidatorApi.Service.v1.Commands
{

    public class CsvValidationPostRequestCommand : IRequest<ValidateableResponse<IEnumerable<CsvValidationPostErrorResponse>>>, IValidateable
    {
        public string FilePath { get; set; } = string.Empty;
        public IEnumerable<PostRuleSetRequest> RuleSet { get; set; } = new List<PostRuleSetRequest>();
    }
}