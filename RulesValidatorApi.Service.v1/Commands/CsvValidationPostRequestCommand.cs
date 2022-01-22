using System.Collections.Generic;
using MediatR;
using RulesValidatorApi.Service.v1.Contracts.V1.Requests;
using RulesValidatorApi.Service.v1.Contracts.V1.Responses;

namespace RulesValidatorApi.Service.v1.Commands
{
    public class CsvValidationPostRequestCommand : IRequest<IEnumerable<CsvValidationPostErrorResponse>>
    {
        public string FilePath { get; set; } = string.Empty;
        public IEnumerable<PostRuleSetRequest> RuleSet { get; set; } = new List<PostRuleSetRequest>();
    }
}